﻿using App.Data.Entities;
using App.Data.MyDbContext;
using App.Data.Repository;
using App.DbServices;
using App.DbServices.MyEntityInterfacess;
using App.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ECommerceDbContext>(options =>
            {
                var connectionString = "Server=DESKTOP-0CKK07Q\\SQLEXPRESS;Database=BE125_ECommerceV1;Trusted_Connection=True;TrustServerCertificate=Yes";
               // options.UseSqlServer(configuration.GetConnectionString("MsSQLConnectionString"));
                options.UseSqlServer(connectionString);
            });
            //services.AddDbContext<ECommerceDbContext>();
            // Generic Repository
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Db Services
            services.AddScoped(typeof(IBaseDbService<>), typeof(BaseDbService<>));
           // services.AddScoped(typeof(BaseDbService<>));
            //services.AddScoped<ProductService>();
            //services.AddScoped<UserService>();
            //services.AddScoped<OrderItemService>();
            //services.AddScoped<OrderService>();
           
            // Logger Service
            services.AddSingleton<ILoggerService, LoggerService>();
        }

    }
}
