using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Entityes;

namespace App.Data.EntityConfigurations
{
    class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Alan özellikleri
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Color).HasMaxLength(6).IsRequired();
            builder.Property(c => c.IconCssClass).HasMaxLength(50).IsRequired();
            builder.Property(c => c.CreatedAt).IsRequired();

            // Çoka-çok ilişki
            builder.HasMany(c => c.ProductCategories)
                .WithOne(pc => pc.Category)
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            var categories = new List<Category>
        {
            new Category { Id = 1, Name = "Elektronik", Color = "primary", IconCssClass = "fas fa-mobile-alt", CreatedAt = DateTime.UtcNow },
            new Category { Id = 2, Name = "Giyim", Color = "secondary", IconCssClass = "fas fa-tshirt", CreatedAt = DateTime.UtcNow },
            new Category { Id = 3, Name = "Ev ve Yaşam", Color = "success", IconCssClass = "fas fa-home", CreatedAt = DateTime.UtcNow },
            new Category { Id = 4, Name = "Anne ve Bebek", Color = "danger", IconCssClass = "fas fa-baby", CreatedAt = DateTime.UtcNow },
            new Category { Id = 5, Name = "Kozmetik", Color = "warning", IconCssClass = "fas fa-spa", CreatedAt = DateTime.UtcNow },
            new Category { Id = 6, Name = "Spor ve Outdoor", Color = "info", IconCssClass = "fas fa-futbol", CreatedAt = DateTime.UtcNow },
            new Category { Id = 7, Name = "Otomobil ve Motosiklet", Color = "dark", IconCssClass = "fas fa-car", CreatedAt = DateTime.UtcNow },
            new Category { Id = 8, Name = "Bilgisayar",Color="primary",IconCssClass="fas fa-computer",CreatedAt=DateTime.UtcNow },
            new Category { Id = 9, Name = "Yaşam", Color = "primary", IconCssClass = "fas fa-mobile-alt", CreatedAt = DateTime.UtcNow },
            new Category { Id = 10, Name = "Telefon", Color = "secondary", IconCssClass = "fas fa-phone", CreatedAt = DateTime.UtcNow},
        };

            builder.HasData(categories);
        }
    }
}
