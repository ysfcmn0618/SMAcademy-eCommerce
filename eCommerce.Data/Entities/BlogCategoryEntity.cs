﻿using App.Data.MyDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Entities;

public class BlogCategoryEntity : EntityBase
{
    public string Name { get; set; } = null!;
}

internal class BlogCategoryEntityConfiguration : IEntityTypeConfiguration<BlogCategoryEntity>
{
    public void Configure(EntityTypeBuilder<BlogCategoryEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
        builder.Property(e => e.CreatedAt).IsRequired();
        new BlogCategoryEntitySeed().SeedData(builder);
    }
}
internal class BlogCategoryEntitySeed : IEntityTypeSeed<BlogCategoryEntity>
{
    public void SeedData(EntityTypeBuilder<BlogCategoryEntity> builder)
    {
        builder.HasData(new List<BlogCategoryEntity> {
            new() { Id = 1, Name = "Beauty", CreatedAt = DateTime.UtcNow },
            new() { Id = 2, Name = "Food", CreatedAt = DateTime.UtcNow },
            new() { Id = 3, Name = "Life Style", CreatedAt = DateTime.UtcNow },
            new() { Id = 4, Name = "Travel", CreatedAt = DateTime.UtcNow },
            new() { Id = 5, Name = "Fashion", CreatedAt = DateTime.UtcNow },
            new() { Id = 7, Name = "Education", CreatedAt = DateTime.UtcNow },
            new() { Id = 8, Name = "Entertainment", CreatedAt = DateTime.UtcNow },
            new() { Id = 9, Name = "Sports", CreatedAt = DateTime.UtcNow }
        });
    }
}