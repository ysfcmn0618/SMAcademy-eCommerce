using App.DbServices.MyEntityInterfacess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Eticaret.ViewComponents
{
    public class CategoriesSliderViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoriesSliderViewComponent(ICategoryService context,IProductService productService)
        {
            _categoryService = context;
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Ürünleri database üzerinden çekiyoruz
            var products = await _productService.GetProductsWithCategoriesAsync();

            var categories = products
                .GroupBy(p => p.CategoryId)
                .Select(g => new CategorySliderViewModel
                {
                    Id = g.First().Category.Id,
                    Name = g.First().Category.Name,
                    Color = g.First().Category.Color,
                    IconCssClass = g.First().Category.IconCssClass,
                    ImageUrl = g.First().Images.Any() ? g.First().Images.First().Url : null
                })
                .ToList();

            return View(categories);
        }
    }
}
