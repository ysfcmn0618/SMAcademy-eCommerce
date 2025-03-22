using System.ComponentModel.DataAnnotations;

namespace App.Admin.Models.CategoryViewModels
{
    public class SaveCategoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!"), MaxLength(100)]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Color { get; set; } = null!;
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string IconCssClass { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}