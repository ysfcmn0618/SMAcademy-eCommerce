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
    class RoleConfig : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .IsRequired();
            builder.Property(x => x.Name)
                .HasMaxLength(10)
                .IsRequired();
            builder.Property(x => x.CreatedAt)
                .IsRequired().HasDefaultValueSql("GETUTCDATE()");

            builder.HasMany<UserEntity>()
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            var roles = new List<RoleEntity>
                    {
                        new RoleEntity { Id = 1, Name = "Admin", CreatedAt = DateTime.UtcNow },
                        new RoleEntity { Id = 2, Name = "Buyer", CreatedAt = DateTime.UtcNow },
                        new RoleEntity { Id = 3, Name = "Seller", CreatedAt = DateTime.UtcNow }
                    };
            builder.HasData(roles);
        }
    }
}
