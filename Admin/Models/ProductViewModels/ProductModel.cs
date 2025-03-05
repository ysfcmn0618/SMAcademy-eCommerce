using System.ComponentModel.DataAnnotations;

namespace App.Admin.Models.ProductViewModels
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int SellerId { get; set; }

        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!"),MinLength(2)]
        public string Name { get; set; }
        [DataType(DataType.Currency), Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        public decimal Price { get; set; }
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string? Details { get; set; }

        [Required,DataType("tinyint")]
        public ushort StockAmount { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool Enabled { get; set; } = true;
    }
}
