using System.ComponentModel.DataAnnotations;

namespace App.eCommerce.Models.ViewModels.OrderViewModels
{
    public class CheckoutViewModel
    {
        [Required, MinLength(10), MaxLength(250), DataType(DataType.MultilineText)]
        public string Address { get; set; } = null!;
    }
}
