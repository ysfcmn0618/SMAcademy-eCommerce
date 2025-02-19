using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class ProductImage
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity),Required]
        public int Id { get; set; }
        [ForeignKey(nameof(ProductId)),Required]
        public int ProductId { get; set; }

        [DataType(DataType.Url), Required,MinLength(10),MaxLength(250)]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Url { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }= DateTime.UtcNow;
    }
}
