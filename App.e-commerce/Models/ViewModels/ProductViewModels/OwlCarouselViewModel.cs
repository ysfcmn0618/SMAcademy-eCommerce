namespace App.eCommerce.Models.ViewModels.ProductViewModels
{
    public class OwlCarouselViewModel
    {
        public string Title { get; set; } = null!;

        public List<ProductListingViewModel> Items { get; set; } = null!;
    }
}
