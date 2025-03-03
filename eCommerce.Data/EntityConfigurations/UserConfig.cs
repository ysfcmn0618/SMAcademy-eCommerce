using App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.EntityConfigurations
{
    public class UserConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            builder.Property(x => x.Password).IsRequired();

            builder.Property(x => x.RoleId).IsRequired();

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.Enabled)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasMany(x => x.Products)
                .WithOne()
                .HasForeignKey(x => x.SellerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<RoleEntity>()
                .WithMany()
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.NoAction);



            var sellers = new List<UserEntity>
                {
                    new UserEntity { Id = 1, FirstName = "Satıcı 1",Password="dasdas" ,LastName = "Satıcı 1", Email = "satici1@example.com", CreatedAt = DateTime.UtcNow ,RoleId=1},
                    new UserEntity { Id = 2, FirstName = "Satıcı 2",Password="dasdas" ,LastName = "Satıcı 1", Email = "satici2@example.com", CreatedAt = DateTime.UtcNow ,RoleId=2},
                    new UserEntity { Id = 3, FirstName = "Satıcı 3",Password="dasdas" ,LastName = "Satıcı 1", Email = "satici3@example.com", CreatedAt = DateTime.UtcNow ,RoleId=3},
                    new UserEntity { Id = 4, FirstName = "Satıcı 4",Password="dasdas" ,LastName = "Satıcı 1", Email = "satici4@example.com", CreatedAt = DateTime.UtcNow ,RoleId=1},
                    new UserEntity { Id = 5, FirstName = "Satıcı 5",Password="dasdas" ,LastName = "Satıcı 1", Email = "satici5@example.com", CreatedAt = DateTime.UtcNow ,RoleId=2},
                    new UserEntity { Id = 6, FirstName = "Satıcı 6",Password="dasdas" ,LastName = "Satıcı 1", Email = "satici6@example.com", CreatedAt = DateTime.UtcNow ,RoleId=3},
                    new UserEntity { Id = 7, FirstName = "Satıcı 7",Password="dasdas" ,LastName = "Satıcı 1", Email = "satici7@example.com", CreatedAt = DateTime.UtcNow ,RoleId=1},
                    new UserEntity { Id = 8, FirstName = "Satıcı 8",Password="dasdas" ,LastName = "Satıcı 1", Email = "satici8@example.com", CreatedAt = DateTime.UtcNow ,RoleId=1}
                };
            builder.HasData(sellers);
        }
    }
}