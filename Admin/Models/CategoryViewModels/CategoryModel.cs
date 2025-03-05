using System.ComponentModel.DataAnnotations;

namespace App.Admin.Models.CategoryViewModels
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string IconCssClass { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}