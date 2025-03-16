using App.Data.Entities;
using App.DbServices.MyEntityInterfacess;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Eticaret.ViewComponents
{
    public class CategoriesSliderViewComponent : ViewComponent
    {
        //private readonly ICategoryService _categoryService;
        private readonly BaseDbService<ProductEntity> _productService;
        private readonly IMapper _mapper;

        public CategoriesSliderViewComponent(BaseDbService<ProductEntity> productService,IMapper mapper)
        {
            //_categoryService = context;
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Ürünleri database üzerinden çekiyoruz
            var products = await _productService.GetAllIncludingAsync();

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
