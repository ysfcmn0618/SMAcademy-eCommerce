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
    class ProductCommentConfig : IEntityTypeConfiguration<ProductCommentEntity>
    {
        public void Configure(EntityTypeBuilder<ProductCommentEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .IsRequired();
            builder.Property(x => x.Text)
                .HasMaxLength(500)
                .IsRequired();
            builder.Property(x => x.StarCount)
                .HasMaxLength(5)
                .IsRequired();
            builder.Property(x => x.IsConfirmed)
                .HasDefaultValue(false)
                .IsRequired();
            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();


            builder.HasOne<UserEntity>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<ProductEntity>()
               .WithMany(x => x.ProductComments)
               .HasForeignKey(x => x.ProductId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
