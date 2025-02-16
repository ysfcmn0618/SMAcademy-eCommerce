using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entityes
{
    public class CategoryEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity),Required]
        public int Id { get; set; }
        [MinLength(2),MaxLength(100), Required]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Name { get; set; }
        [MinLength(2), MaxLength(50), Required]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Color { get; set; }
        [MinLength(2), MaxLength(50), Required]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string IconCssClass { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
