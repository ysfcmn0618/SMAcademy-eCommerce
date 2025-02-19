﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Data.Entities;

namespace App.Data.EntityConfigurations
{
    class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.CreatedAt)
                .IsRequired().HasDefaultValue(DateTime.UtcNow);

            builder.HasMany<User>()
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            var roles = new List<Role>
                    {
                        new Role { Id = 1, Name = "Admin", CreatedAt = DateTime.UtcNow },
                        new Role { Id = 2, Name = "Buyer", CreatedAt = DateTime.UtcNow },
                        new Role { Id = 3, Name = "Seller", CreatedAt = DateTime.UtcNow }
                    };
            builder.HasData(roles);
        }
    }
}
