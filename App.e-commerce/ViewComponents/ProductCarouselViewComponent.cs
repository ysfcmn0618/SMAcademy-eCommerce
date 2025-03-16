using App.Data.Entities;
using App.DbServices.MyEntityInterfacess;
using App.eCommerce.Models.ViewModels.HomeViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.eCommerce.ViewComponents
{
    public class ProductCarouselViewComponent : ViewComponent
    {
        private readonly BaseDbService<ProductEntity> _productService;
        private readonly IMapper _mapper;

        public ProductCarouselViewComponent(BaseDbService<ProductEntity> productService,IMapper mapper)
        {
            _productService= productService;
            _mapper= mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await GetProductsAsync();
            return View(products);
        }

        private async Task<List<ProductViewComponentModel>> GetProductsAsync()
        {
            var products = await _productService.GetAllIncludingAsync(p=>p.Images);
           var productList= products.OrderByDescending(p=>p.CreatedAt).Take(5);
            var mappintProductList = _mapper.Map<IEnumerable<ProductViewComponentModel>>(productList);

            return mappintProductList.ToList();            
        }
    }  
}
