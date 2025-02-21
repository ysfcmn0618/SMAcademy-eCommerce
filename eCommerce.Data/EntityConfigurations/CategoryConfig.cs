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
    class CategoryConfig : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            // Alan özellikleri
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Color).HasMaxLength(7).IsRequired();
            builder.Property(c => c.IconCssClass).HasMaxLength(50).IsRequired();
            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETUTCDATE()").IsRequired();

            // Çoka-çok ilişki
            builder.HasMany(c => c.ProductCategories)
                .WithOne(pc => pc.Category)
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            var categories = new List<CategoryEntity>
        {
    new CategoryEntity { Id = 1, Name = "Elektronik", Color = "#007bff", IconCssClass = "fas fa-mobile-alt", CreatedAt = DateTime.UtcNow },
    new CategoryEntity { Id = 2, Name = "Giyim", Color = "#6c757d", IconCssClass = "fas fa-tshirt", CreatedAt = DateTime.UtcNow },
    new CategoryEntity { Id = 3, Name = "Ev ve Yaşam", Color = "#28a745", IconCssClass = "fas fa-home", CreatedAt = DateTime.UtcNow },
    new CategoryEntity { Id = 4, Name = "Anne ve Bebek", Color = "#dc3545", IconCssClass = "fas fa-baby", CreatedAt = DateTime.UtcNow },
    new CategoryEntity { Id = 5, Name = "Kozmetik", Color = "#ffc107", IconCssClass = "fas fa-spa", CreatedAt = DateTime.UtcNow },
    new CategoryEntity { Id = 6, Name = "Spor ve Outdoor", Color = "#17a2b8", IconCssClass = "fas fa-futbol", CreatedAt = DateTime.UtcNow },
    new CategoryEntity { Id = 7, Name = "Otomobil ve Motosiklet", Color = "#343a40", IconCssClass = "fas fa-car", CreatedAt = DateTime.UtcNow },
    new CategoryEntity { Id = 8, Name = "Bilgisayar", Color = "#007bff", IconCssClass = "fas fa-computer", CreatedAt = DateTime.UtcNow },
    new CategoryEntity { Id = 9, Name = "Yaşam", Color = "#007bff", IconCssClass = "fas fa-mobile-alt", CreatedAt = DateTime.UtcNow },
    new CategoryEntity { Id = 10, Name = "Telefon", Color = "#6c757d", IconCssClass = "fas fa-phone", CreatedAt = DateTime.UtcNow },
        };

            builder.HasData(categories);
        }
    }
}
