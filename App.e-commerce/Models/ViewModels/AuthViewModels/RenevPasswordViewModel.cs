using System.ComponentModel.DataAnnotations;

namespace App.eCommerce.Models.ViewModels.AuthViewModels
{
    public class RenevPasswordViewModel
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!"), DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!"), DataType(DataType.Password)]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!"), DataType(DataType.Password), Compare(nameof(Password), ErrorMessage = "Şifreler Eşleşmelidir.")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
