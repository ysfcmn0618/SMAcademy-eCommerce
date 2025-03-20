﻿using System.ComponentModel.DataAnnotations;

namespace App.eCommerce.Models.ViewModels.ProfileViewModels
{
    public class ProfileDetailsViewModel
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = null!;

        [Required, MaxLength(256), EmailAddress]
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
    }
}
