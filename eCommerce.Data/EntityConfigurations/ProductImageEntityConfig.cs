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
    class ProductImageEntityConfig : IEntityTypeConfiguration<ProductImageEntity>
    {
        public void Configure(EntityTypeBuilder<ProductImageEntity> builder)
        {
            builder.Property(u => u.Id)
               .ValueGeneratedOnAdd();
        }
    }
}
