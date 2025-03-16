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
            var products = await _productService.GetAll();
           var productList= products.OrderByDescending(p=>p.CreatedAt).Take(5);
            var mappintProductList = _mapper.Map<IEnumerable<ProductViewComponentModel>>(productList);

            return mappintProductList.ToList();

            // return Task.FromResult(new List<ProductViewComponentModel>
            //{
            //    new ProductViewComponentModel{Id=1,Img="theme/img/categories/cat-1.jpg",Name="Drink Fruits"},
            //         new ProductViewComponentModel{Id=2,Img="theme/img/categories/cat-2.jpg",Name="Dried Fruits"},
            //         new ProductViewComponentModel{Id=3,Img="theme/img/categories/cat-3.jpg",Name="Fresh Fruits"},
            //         new ProductViewComponentModel{Id=4,Img="theme/img/categories/cat-4.jpg",Name="Vegetables"},
            //         new ProductViewComponentModel{Id=5,Img="theme/img/categories/cat-5.jpg",Name="Bla bla Fruits"},
            //});
        }
    }  
}
