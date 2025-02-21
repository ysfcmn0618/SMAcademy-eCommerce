using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Entities;
using System.Reflection.Emit;

namespace App.Data.EntityConfigurations
{
    class CartItemConfig : IEntityTypeConfiguration<CartItemEntity>
    {
        public void Configure(EntityTypeBuilder<CartItemEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .UseIdentityColumn()
                .IsRequired();
            builder.Property(p => p.Quantity)
                .HasColumnType("tinyint")
                .IsRequired();
            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();

            builder.HasOne<UserEntity>()
                 .WithMany()
                 .HasForeignKey(p => p.UserId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<ProductEntity>()
                .WithMany()
                .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
