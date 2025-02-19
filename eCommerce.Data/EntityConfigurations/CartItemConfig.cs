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
    class CartItemConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //builder.HasOne<Cart>() //Cart classı silindiği için bu alanı sildik
            //    .WithMany(x => x.Items)
            //    .HasForeignKey(x => x.CardId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne<Product>()
            //    .WithOne<Product>()
            //    .HasForeignKey(x=>x.ProductId);

            //builder.HasOne<User>()
            //    .WithMany()
            //    .HasForeignKey(x => x.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
