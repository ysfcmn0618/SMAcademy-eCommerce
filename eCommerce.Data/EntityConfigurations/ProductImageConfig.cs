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
    class ProductImageConfig : IEntityTypeConfiguration<ProductImageEntity>
    {
        public void Configure(EntityTypeBuilder<ProductImageEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .IsRequired();
            builder.Property(x => x.Url)
                .HasColumnType("nvarchar(255)")
                .IsRequired();
            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne<ProductEntity>()
               .WithMany(x => x.ProductImages)
               .HasForeignKey(x => x.ProductId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
