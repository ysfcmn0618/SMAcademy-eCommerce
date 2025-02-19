using App.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using App.Data.Entities;

namespace App.Data.ECommerceDbContext
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> CartItems { get; set; }
        //public DbSet<Cart> Cart { get; set; } // Cart classı silindiği için bu alanı sildik
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new ProductImageConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new ProductCommentConfig());
            modelBuilder.ApplyConfiguration(new OrderItemConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new CartItemConfig());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfig());
        }
    }
}
