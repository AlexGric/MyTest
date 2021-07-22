using DataAccess.Context;
using DataAccess.Repository;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Infrastructure
{
    public static class DataAccessConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IAdvertisementRepository), typeof(AdvertisementRepository));
            services.AddTransient(typeof(ICategoryRepository), typeof(CategoryRepository));

            services.AddDbContext<AdvertisementContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("AdvertisementConnection")));
        }
    }
}