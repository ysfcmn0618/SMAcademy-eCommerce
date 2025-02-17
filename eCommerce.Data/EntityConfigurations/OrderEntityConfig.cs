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
    class OrderEntityConfig : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.OrderCode).IsRequired().HasMaxLength(255); // Örnek olarak MaxLength ekledim.
            builder.Property(o => o.Address).IsRequired().HasMaxLength(250);

          
        
        }
    }
}
