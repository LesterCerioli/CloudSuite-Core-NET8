using CloudSuite.Infrastructure.Context;
using CloudSuite.Modules.Application.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace CloudSuite.Infrastructure.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Infrastructure
            //services.AddScoped<IAddressRepository>();
            //services.AddScoped<ICityRepository>();
            //services.AddScoped<ICompanyRepository>();
            //services.AddScoped<ICountryRepository>();
            //services.AddScoped<IDistrictRepository>();
            //services.AddScoped<IEmailRepository>();
            //services.AddScoped<IStateRepository>();
            //services.AddScoped<IUserRepository>();
            //services.AddScoped<IVendorRepository>();
            //services.AddScoped<CoreDbContextContext>();

            // Application
            //services.AddScoped<IAddressAppService, AddressAppServiceService>();
        }
    }
}