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
    class CartItemEntityConfig : IEntityTypeConfiguration<CartItemEntity>
    {
        public void Configure(EntityTypeBuilder<CartItemEntity> builder)
        {
            builder.Property(u => u.Id)
               .ValueGeneratedOnAdd();
        }
    }
}
