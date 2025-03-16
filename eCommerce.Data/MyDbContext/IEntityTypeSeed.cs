using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.MyDbContext
{
    public interface IEntityTypeSeed<T> where T : class
    {
        void SeedData(EntityTypeBuilder<T> builder);
    }
}