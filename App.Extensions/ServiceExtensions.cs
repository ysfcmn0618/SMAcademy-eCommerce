using App.Data.Entities;
using App.Data.Repository;
using App.DbServices;
using App.DbServices.MyEntityInterfacess;
using App.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace App.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            // Generic Repository
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Db Services
            services.AddScoped(typeof(IBaseServiceInterface<>), typeof(BaseDbService<>));
            services.AddScoped(typeof(BaseDbService<>));
            services.AddScoped<ProductService>();
            services.AddScoped<UserService>();
            services.AddScoped<OrderItemService>();
            services.AddScoped<OrderService>();
           
            // Logger Service
            services.AddSingleton<ILoggerService, LoggerService>();
        }

    }
}
