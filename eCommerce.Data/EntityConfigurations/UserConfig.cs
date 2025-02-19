using App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.EntityConfigurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.Products)
                .WithOne()
                .HasForeignKey(x => x.SellerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Role>()
                .WithMany()
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.NoAction);



            var sellers = new List<User>
                {
                    new User { Id = 1, FirstName = "Satıcı 1",Password="dasdas" ,LastName = "Satıcı 1", Email = "satici1@example.com", CreatedAt = DateTime.UtcNow ,RoleId=1},
                    new User { Id = 2, FirstName = "Satıcı 2",Password="dasdas" ,LastName = "Satıcı 1", Email = "satici2@example.com", CreatedAt = DateTime.UtcNow ,RoleId=2},
                    new User { Id = 3, FirstName = "Satıcı 3",Password="dasdas" ,LastName = "Satıcı 1", Email = "satici1@example.com", CreatedAt = DateTime.UtcNow ,RoleId=3},
                    new User { Id = 4, FirstName = "Satıcı 4",Password="dasdas" ,LastName = "Satıcı 1", Email = "satici2@example.com", CreatedAt = DateTime.UtcNow ,RoleId=1},
                    new User { Id = 5, FirstName = "Satıcı 5",Password="dasdas" ,LastName = "Satıcı 1", Email = "satici1@example.com", CreatedAt = DateTime.UtcNow ,RoleId=2},
                    new User { Id = 6, FirstName = "Satıcı 6",Password="dasdas" ,LastName = "Satıcı 1", Email = "satici2@example.com", CreatedAt = DateTime.UtcNow ,RoleId=3},
                    new User { Id = 7, FirstName = "Satıcı 7",Password="dasdas" ,LastName = "Satıcı 1", Email = "satici1@example.com", CreatedAt = DateTime.UtcNow ,RoleId=1},
                    new User { Id = 8, FirstName = "Satıcı 8",Password="dasdas" ,LastName = "Satıcı 1", Email = "satici2@example.com", CreatedAt = DateTime.UtcNow ,RoleId=1}
                };
            builder.HasData(sellers);
        }
    }
}