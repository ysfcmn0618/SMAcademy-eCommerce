using App.Data.MyDbContext;
using App.Data.Repository;
using App.DbServices.MyEntityInterfacess;
using App.DbServices;
using Microsoft.EntityFrameworkCore;
using App.eCommerce.Mapping;
using App.Logging;
using App.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped<ICartItemService, CartItemService>();
//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IRoleService, RoleService>();
//builder.Services.AddScoped<IOrderItemService, OrderItemService>();
//builder.Services.AddScoped<IOrderService, OrderService>();
//builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
//builder.Services.AddScoped<IProductCommentService, ProductCommentService>();
//builder.Services.AddScoped<IProductImageService, ProductImageService>();

builder.Services.ConfigureServices(builder.Configuration);

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(ECommerceMappingProfile));
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
});
builder.Services.AddSingleton<ILoggerService, LoggerService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
using (var scope = app.Services.CreateScope())
{
    using (var dbContext = scope.ServiceProvider.GetRequiredService<ECommerceDbContext>())
    {
        await dbContext.Database.EnsureDeletedAsync();
        await dbContext.Database.EnsureCreatedAsync();
    }
}

app.Run();
