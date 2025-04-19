using App.Data.Entities;
using App.Data.Infrastructure.MyDbContext;
using App.Data.Repository;
using App.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace App.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services,IConfiguration configuration)
        {
            string connectionString = "Server=DESKTOP-0CKK07Q\\SQLEXPRESS;Database=BE125_ECommerceV1;Trusted_Connection=True;TrustServerCertificate=Yes";
            services.AddDbContext<ECommerceDbContext>(options =>
            {
               
               // options.UseSqlServer(configuration.GetConnectionString("MsSQLConnectionString"));
                options.UseSqlServer(connectionString);
            });
            //services.AddDbContext<ECommerceDbContext>();
            // Generic Repository
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.MapInboundClaims = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                    RoleClaimType = "role",
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = false,
                    SignatureValidator = (token, parameters) => new JwtSecurityToken(token)
                };
            });

            // Logger Service
            services.AddSingleton<ILoggerService, LoggerService>();
        }

    }
}
