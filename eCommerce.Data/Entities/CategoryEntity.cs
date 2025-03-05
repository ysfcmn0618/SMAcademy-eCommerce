using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string IconCssClass { get; set; }        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Eğer bire-çok ilişki kullanıyorsan (Products varsa)
        //[JsonIgnore]
        //public List<ProductEntity>? Products { get; set; }
        public ICollection<ProductCategoryEntity> ?ProductCategories { get; set; }
    }
}
