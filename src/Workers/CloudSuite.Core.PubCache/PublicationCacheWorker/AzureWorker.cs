using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Files.DataLake;
using Azure.Storage;
using Microsoft.Data.SqlClient;

namespace CloudSuite.Core.PubCache.PublicationCacheWorker
{
    public class AzureWorker : BackgroundService
    {
        private readonly ILogger<AzureWorker> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly string _accountName;
        private readonly string _accountKey;
        private readonly string _fileSystemName;
        private readonly string _directoryName;

        private readonly string[] _tableNames = new string[]
        {
            "mscore_companies",
            "mscore_cities",
            "mscore_addresses",
            "mscore_countries",
            "mscore_districts",
            "mscore_medias",
            "mscore_states"
        };

        public AzureWorker(ILogger<AzureWorker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
            _accountName = _configuration["AzureDataLake:AccountName"];
            _accountKey = _configuration["AzureDataLake:AccountKey"];
            _fileSystemName = _configuration["AzureDataLake:FileSystemName"];
            _directoryName = _configuration["AzureDataLake:DirectoryName"];
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                foreach (var tableName in _tableNames)
                {
                    var data = await FetchDataFromSqlServer(tableName);
                    var json = JsonSerializer.Serialize(data);

                    await UploadToAzureDataLake(json, tableName);
                }
                await Task.Delay(10000, stoppingToken); // Delay for 10 seconds before the next execution
            }
        }

        private async Task<DataTable> FetchDataFromSqlServer(string tableName)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = $"SELECT * FROM {tableName}"; // Query to fetch data from the specified table
            using var command = new SqlCommand(query, connection);
            using var adapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }

        private async Task UploadToAzureDataLake(string jsonData, string tableName)
        {
            var serviceClient = new DataLakeServiceClient(new Uri($"https://{_accountName}.dfs.core.windows.net"),
                new StorageSharedKeyCredential(_accountName, _accountKey));
            var fileSystemClient = serviceClient.GetFileSystemClient(_fileSystemName);
            var directoryClient = fileSystemClient.GetDirectoryClient(_directoryName);

            var fileName = $"{tableName}_{DateTime.UtcNow:yyyyMMdd_HHmmss}.json";
            var fileClient = directoryClient.GetFileClient(fileName);

            await using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(jsonData));
            await fileClient.UploadAsync(stream, overwrite: true);
        }
    }
}
