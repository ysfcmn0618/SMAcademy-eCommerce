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
    public class Product
    {       

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int Id { get; set; }
        [ForeignKey(nameof(UserId)), Required]
        public int UserId { get; set; }
        //public User SellerPerson { get; set; }

        [ForeignKey(nameof(CategoryId)), Required]
        public int CategoryId { get; set; }
        //public CategoryEntity Category { get; set; }
        [MinLength(2), MaxLength(100), Required]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Name { get; set; }

        [DataType(DataType.Currency), Required]
        public decimal Price { get; set; }

        [MaxLength(1000)]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string? Details { get; set; }

        [Required]
        public ushort StockAmount { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool Enabled { get; set; } = true;

        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<ProductComment> ProductComments { get; set; }
        [JsonIgnore]
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
