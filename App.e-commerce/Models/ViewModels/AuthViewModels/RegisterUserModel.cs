using System.ComponentModel.DataAnnotations;

namespace App.eCommerce.Models.ViewModels.AuthViewModels
{
    public class RegisterUserModel
    {       
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!"), MinLength(2,ErrorMessage ="En az 2 karakter girilmelidir")]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Name { get; set; }=null!;
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!"), MinLength(2, ErrorMessage = "En az 2 karakter girilmelidir")]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Surname { get; set; } = null!;
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!"), DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!"), DataType(DataType.Password)]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!"), DataType(DataType.Password), Compare(nameof(Password),ErrorMessage ="Şifreler Eşleşmelidir.")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
