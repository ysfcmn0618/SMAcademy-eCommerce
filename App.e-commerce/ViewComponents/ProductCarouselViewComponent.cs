using Microsoft.AspNetCore.Mvc;

namespace App.eCommerce.ViewComponents
{
    public class ProductCarouselViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await GetProductsAsync();
            return View(products);
        }

        private Task<List<Product>> GetProductsAsync()
        {
            return Task.FromResult(new List<Product>
           {
               new Product{Id=1,Img="img/categories/cat-1.jpg",Name="Drink Fruits"},
                    new Product{Id=2,Img="img/categories/cat-2.jpg",Name="Dried Fruits"},
                    new Product{Id=3,Img="img/categories/cat-3.jpg",Name="Fresh Fruits"},
                    new Product{Id=4,Img="img/categories/cat-4.jpg",Name="Vegetables"},
                    new Product{Id=5,Img="img/categories/cat-5.jpg",Name="Bla bla Fruits"},
           });
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Img { get; set; }
        public string Name { get; set; }
    }
}
