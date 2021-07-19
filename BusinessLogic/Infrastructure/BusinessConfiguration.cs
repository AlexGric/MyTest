using BusinessLogic.Services;
using DataAccess.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Infrastructure
{
    public static class BusinessConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //services
            services.AddTransient(typeof(AdvertisementService));
            services.AddTransient(typeof(CategoryService));

            DataAccessConfiguration.ConfigureServices(services, configuration);
        }
    }
}