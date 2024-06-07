using Azure.Storage.Blobs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Xml.Serialization;

namespace CloudSuite.Worker.DataLaker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly CronScheduler.Scheduler.CronScheduler _scheduler;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _scheduler = new CronScheduler.Scheduler.CronScheduler(configuration["JobSchedule"]);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _scheduler.OnSchedule += async (sender, args) =>
            {
                if (!stoppingToken.IsCancellationRequested)
                {
                    await ImportDataAsync();
                }
            };

            _scheduler.Start();

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }

        private async Task ImportDataAsync()
        {
            _logger.LogWarning("Import data at: {time}", DateTimeOffset.Now);

            string connectionString = _configuration.GetConnectionString("SqlServer");
            string blobStorageConnectionString = _configuration["Azure:BlobStorageConnectionString"];
            string containerName = _configuration["Azure:ContainerName"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("SELECT * FROM TableName", connection);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    var csv = new System.Text.StringBuilder();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        csv.Append(reader.GetName(i) + ",");
                    }
                    csv.Length--;
                    csv.AppendLine();

                    while (await reader.ReadAsync())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            csv.Append(reader.GetValue(i).ToString().Replace(",", ";") + ",");
                        }
                        csv.Length--; // Remove trailing comma
                        csv.AppendLine();
                    }
                    string fileName = $"data_{DateTime.UtcNow.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture)}.csv";
                    BlobServiceClient blobServiceClient = new BlobServiceClient(blobStorageConnectionString);
                    BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                    BlobClient blobClient = containerClient.GetBlobClient(fileName);

                    using (var stream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(csv.ToString())))
                    {
                        await blobClient.UploadAsync(stream, true);
                    }

                }
            }
            _logger.LogWarning("Data import successfully.")
        }
    }
}
