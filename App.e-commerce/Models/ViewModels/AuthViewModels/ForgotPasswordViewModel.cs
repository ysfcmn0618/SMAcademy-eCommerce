using System.ComponentModel.DataAnnotations;

namespace App.eCommerce.Models.ViewModels.AuthViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!"), DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Email { get; set; }
    }
}
