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
    class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Seller ile bire-çok ilişki
            builder.HasOne<User>()
                .WithMany(x=>x.Products)
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.NoAction);

            // Çoka-çok ilişkiyi tanımla
            builder.HasMany(p => p.ProductCategories)
                .WithOne(pc => pc.Product)
                .HasForeignKey(pc => pc.ProductId);           

            // `CreatedAt` için varsayılan değer
            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
                      

            // 20 adet örnek veri ekleyelim
            var products = new List<Product>
        {
            new Product { Id = 1, SellerId = 1, CategoryId = 1, Name = "Akıllı Telefon", Price = 2000, StockAmount = 50, CreatedAt = DateTime.UtcNow },
            new Product { Id = 2, SellerId = 2, CategoryId = 2, Name = "T-Shirt", Price = 100, StockAmount = 150, CreatedAt = DateTime.UtcNow },
            new Product { Id = 3, SellerId = 3, CategoryId = 3, Name = "Yatak", Price = 1200, StockAmount = 30, CreatedAt = DateTime.UtcNow },
            new Product { Id = 4, SellerId = 4, CategoryId = 4, Name = "Bebek Arabası", Price = 500, StockAmount = 70, CreatedAt = DateTime.UtcNow },
            new Product { Id = 5, SellerId = 5, CategoryId = 5, Name = "Cilt Bakım Kremi", Price = 150, StockAmount = 80, CreatedAt = DateTime.UtcNow },
            new Product { Id = 6, SellerId = 6, CategoryId = 6, Name = "Futbol Topu", Price = 80, StockAmount = 200, CreatedAt = DateTime.UtcNow },
            new Product { Id = 7, SellerId = 7, CategoryId = 7, Name = "Araba Lastiği", Price = 350, StockAmount = 60, CreatedAt = DateTime.UtcNow },
            new Product { Id = 8, SellerId = 1, CategoryId = 8, Name = "Laptop", Price = 5000, StockAmount = 40, CreatedAt = DateTime.UtcNow },
            new Product { Id = 9, SellerId = 2, CategoryId = 1, Name = "Tablet", Price = 1800, StockAmount = 55, CreatedAt = DateTime.UtcNow },
            new Product { Id = 10, SellerId = 3, CategoryId = 3, Name = "Lamba", Price = 200, StockAmount = 120, CreatedAt = DateTime.UtcNow },
            new Product { Id = 11, SellerId = 4, CategoryId = 5, Name = "Şampuan", Price = 80, StockAmount = 180, CreatedAt = DateTime.UtcNow },
            new Product { Id = 12, SellerId = 5, CategoryId = 6, Name = "Yoga Matı", Price = 250, StockAmount = 90, CreatedAt = DateTime.UtcNow },
            new Product { Id = 13, SellerId = 6, CategoryId = 7, Name = "Motor Yağı", Price = 150, StockAmount = 40, CreatedAt = DateTime.UtcNow },
            new Product { Id = 14, SellerId = 7, CategoryId = 8, Name = "Masaüstü Bilgisayar", Price = 3500, StockAmount = 30, CreatedAt = DateTime.UtcNow },
            new Product { Id = 15, SellerId = 1, CategoryId = 2, Name = "Pantolon", Price = 300, StockAmount = 75, CreatedAt = DateTime.UtcNow },
            new Product { Id = 16, SellerId = 2, CategoryId = 5, Name = "Parfüm", Price = 450, StockAmount = 60, CreatedAt = DateTime.UtcNow },
            new Product { Id = 17, SellerId = 3, CategoryId = 4, Name = "Bebek Bezi", Price = 40, StockAmount = 300, CreatedAt = DateTime.UtcNow },
            new Product { Id = 18, SellerId = 4, CategoryId = 1, Name = "Akıllı Saat", Price = 700, StockAmount = 100, CreatedAt = DateTime.UtcNow },
            new Product { Id = 19, SellerId = 5, CategoryId = 8, Name = "Monitör", Price = 1200, StockAmount = 50, CreatedAt = DateTime.UtcNow },
            new Product { Id = 20, SellerId = 6, CategoryId = 3, Name = "Koltuk Takımı", Price = 2500, StockAmount = 35, CreatedAt = DateTime.UtcNow }
        };

            builder.HasData(products);
        }
    }
}

