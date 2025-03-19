﻿using System.ComponentModel.DataAnnotations;

namespace App.eCommerce.Models.ViewModels.AuthViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!"), DataType(DataType.EmailAddress),MaxLength(256)]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!"), DataType(DataType.Password)]
        [RegularExpression(@"^\S.*$", ErrorMessage = "Boşluk ile başlamaz!")]
        public string Password { get; set; } = null!;
    }
}