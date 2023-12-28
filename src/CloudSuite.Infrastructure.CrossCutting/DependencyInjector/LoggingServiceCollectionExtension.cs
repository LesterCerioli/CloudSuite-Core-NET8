using CloudSuite.Infrastructure.CrossCutting.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace CloudSuite.Infrastructure.CrossCutting.DependencyInjector
{
    public static class LoggingServiceCollectionExtension
    {
        public static IServiceCollection AddLogger(this IServiceCollection services)
        {
            var logger = LoggerManager.CreateLogger();
            services.AddSingleton(logger);
            return services;
        }
    }
}