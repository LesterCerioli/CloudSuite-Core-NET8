using CloudSuite.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Services.Core.API.Configurations
{
    public static class DatabaseConfig
    {
        public static void guration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<CoreDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
