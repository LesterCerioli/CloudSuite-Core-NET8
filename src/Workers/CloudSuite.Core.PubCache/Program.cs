using CloudSuite.Core.PubCache.PublicationCacheWorker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostContext, config) =>
    {
        var env = hostContext.HostingEnvironment;
        var appSettingsPath = Path.Combine(env.ContentRootPath, "..", "CloudSuite.Core.PubCache", "appsettings.json");

        config.AddJsonFile(appSettingsPath, optional: false, reloadOnChange: true);
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<AzureWorker>();
    })
    .Build();

await host.RunAsync();
