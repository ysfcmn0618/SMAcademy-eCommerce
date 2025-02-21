using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Entities;

namespace App.Data.EntityConfigurations
{
    class ProductConfig : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .UseIdentityColumn()
                .IsRequired();
            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            builder.Property(p => p.StockAmount)
                .HasColumnType("tinyint")
                .IsRequired();
            builder.Property(p => p.Details)
                .HasMaxLength(1000);
            builder.Property(x=>x.Enabled)
                .HasDefaultValue(true)
                .IsRequired();
            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()").IsRequired();

            builder.HasOne<UserEntity>()
                .WithMany(x=>x.Products)
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(p => p.ProductCategories)
                .WithOne(pc => pc.Product)
                .HasForeignKey(pc => pc.ProductId);           

           
            
                      

            var products = new List<ProductEntity>
        {
            new ProductEntity { Id = 1, SellerId = 1, CategoryId = 1, Name = "Akıllı Telefon", Price = 2000, StockAmount = 50, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 2, SellerId = 2, CategoryId = 2, Name = "T-Shirt", Price = 100, StockAmount = 150, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 3, SellerId = 3, CategoryId = 3, Name = "Yatak", Price = 1200, StockAmount = 30, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 4, SellerId = 4, CategoryId = 4, Name = "Bebek Arabası", Price = 500, StockAmount = 70, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 5, SellerId = 5, CategoryId = 5, Name = "Cilt Bakım Kremi", Price = 150, StockAmount = 80, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 6, SellerId = 6, CategoryId = 6, Name = "Futbol Topu", Price = 80, StockAmount = 200, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 7, SellerId = 7, CategoryId = 7, Name = "Araba Lastiği", Price = 350, StockAmount = 60, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 8, SellerId = 1, CategoryId = 8, Name = "Laptop", Price = 5000, StockAmount = 40, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 9, SellerId = 2, CategoryId = 1, Name = "Tablet", Price = 1800, StockAmount = 55, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 10, SellerId = 3, CategoryId = 3, Name = "Lamba", Price = 200, StockAmount = 120, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 11, SellerId = 4, CategoryId = 5, Name = "Şampuan", Price = 80, StockAmount = 180, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 12, SellerId = 5, CategoryId = 6, Name = "Yoga Matı", Price = 250, StockAmount = 90, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 13, SellerId = 6, CategoryId = 7, Name = "Motor Yağı", Price = 150, StockAmount = 40, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 14, SellerId = 7, CategoryId = 8, Name = "Masaüstü Bilgisayar", Price = 3500, StockAmount = 30, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 15, SellerId = 1, CategoryId = 2, Name = "Pantolon", Price = 300, StockAmount = 75, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 16, SellerId = 2, CategoryId = 5, Name = "Parfüm", Price = 450, StockAmount = 60, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 17, SellerId = 3, CategoryId = 4, Name = "Bebek Bezi", Price = 40, StockAmount = 250, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 18, SellerId = 4, CategoryId = 1, Name = "Akıllı Saat", Price = 700, StockAmount = 100, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 19, SellerId = 5, CategoryId = 8, Name = "Monitör", Price = 1200, StockAmount = 50, CreatedAt = DateTime.UtcNow },
            new ProductEntity { Id = 20, SellerId = 6, CategoryId = 3, Name = "Koltuk Takımı", Price = 2500, StockAmount = 35, CreatedAt = DateTime.UtcNow }
        };

            builder.HasData(products);
        }
    }
}

