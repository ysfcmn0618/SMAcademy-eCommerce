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
    class CartItemConfig : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
           // builder.HasOne<User>()
                 //.WithMany(x => x.CartItems)
                 //.HasForeignKey(p => p.UserId);
        }
    }
}
