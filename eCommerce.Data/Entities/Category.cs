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
    public class Category
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity),Required]
        public int Id { get; set; }
        [MinLength(2)]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Name { get; set; }
        [MinLength(3)]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Color { get; set; }
        [MinLength(2)]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string IconCssClass { get; set; }        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Eğer bire-çok ilişki kullanıyorsan (Products varsa)
        //[JsonIgnore]
        //public List<ProductEntity>? Products { get; set; }
        [JsonIgnore]
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
