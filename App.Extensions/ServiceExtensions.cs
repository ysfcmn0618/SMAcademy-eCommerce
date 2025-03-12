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
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductCommentService, ProductCommentService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IBlogCategoryService,BlogCategoryService>();
            services.AddScoped<IBlogCommentService,BlogCommentService>();
            services.AddScoped<IBlogService,BlogService>();
            services.AddScoped<IBlogTagService,BlogTagService>();
            services.AddScoped<IContactFormService, ContactFormService>();
            services.AddScoped<IDiscountService,DiscountService>();
            services.AddScoped<IRelBlogCategoryService, RelBlogCategoryService>();
            services.AddScoped<IRelBlogTagService, RelBlogTagService>();

            // Logger Service
            services.AddSingleton<ILoggerService, LoggerService>();
        }

    }
}
