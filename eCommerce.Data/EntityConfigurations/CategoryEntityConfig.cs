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
    class CategoryEntityConfig : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.Property(u => u.Id)
               .ValueGeneratedOnAdd();
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Color).HasMaxLength(50).IsRequired();
            builder.Property(x => x.IconCssClass).HasMaxLength(50).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);

            var categories = new List<CategoryEntity>
            {
                new CategoryEntity { Id = 1, Name = "Elektronik", Color = "primary", IconCssClass = "fas fa-mobile-alt", CreatedAt = DateTime.UtcNow },
                new CategoryEntity { Id = 2, Name = "Giyim", Color = "secondary", IconCssClass = "fas fa-tshirt", CreatedAt = DateTime.UtcNow },
                new CategoryEntity { Id = 3, Name = "Ev ve Yaşam", Color = "success", IconCssClass = "fas fa-home", CreatedAt = DateTime.UtcNow },
                new CategoryEntity { Id = 4, Name = "Anne ve Bebek", Color = "danger", IconCssClass = "fas fa-baby", CreatedAt = DateTime.UtcNow },
                new CategoryEntity { Id = 5, Name = "Kozmetik", Color = "warning", IconCssClass = "fas fa-spa", CreatedAt = DateTime.UtcNow },
                new CategoryEntity { Id = 6, Name = "Spor ve Outdoor", Color = "info", IconCssClass = "fas fa-futbol", CreatedAt = DateTime.UtcNow },
                new CategoryEntity { Id = 7, Name = "Otomobil ve Motosiklet", Color = "dark", IconCssClass = "fas fa-car", CreatedAt = DateTime.UtcNow },
                new CategoryEntity { Id = 8, Name = "Bilgisayar",Color="primary",IconCssClass="fas fa-computer",CreatedAt=DateTime.UtcNow },
                new CategoryEntity { Id = 9, Name = "Yaşam", Color = "primary", IconCssClass = "fas fa-mobile-alt", CreatedAt = DateTime.UtcNow },
                new CategoryEntity { Id = 10, Name = "Telefon", Color = "secondary", IconCssClass = "fas fa-phone", CreatedAt = DateTime.UtcNow},

            };
            builder.HasData(categories);
        }
    }
}
