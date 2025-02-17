using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entityes
{
    public class ProductEntity
    {       

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int Id { get; set; }
        [ForeignKey(nameof(SellerId)), Required]
        public int SellerId { get; set; }
        public SellerEntity SellerPerson { get; set; }
        [ForeignKey(nameof(CategoryId)), Required]
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        [MinLength(2), MaxLength(100), Required]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Name { get; set; }
        [DataType(DataType.Currency), Required]
        public decimal Price { get; set; }
        [MaxLength(1000)]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Details { get; set; }
        [Required]
        public byte StockAmount { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool Enabled { get; set; } = true;
        public List<ProductImageEntity> ProductImages { get; set; }
        public List<ProductCommentEntity> ProductComments { get; set; }
    }
}
