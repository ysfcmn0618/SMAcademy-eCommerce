using App.Data.Repository;
using Microsoft.EntityFrameworkCore;
using App.eCommerce.Mapping;
using App.Logging;
using App.Extensions;
using App.Data.Infrastructure.MyDbContext;

var builder = WebApplication.CreateBuilder(args);

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
