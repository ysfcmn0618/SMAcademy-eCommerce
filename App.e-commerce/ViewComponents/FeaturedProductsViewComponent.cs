using App.Data.Entities;
using App.DbServices.MyEntityInterfacess;
using App.eCommerce.Models.ViewModels.ProductViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Eticaret.ViewComponents
{
    public class FeaturedProductsViewComponent : ViewComponent
    {
        private readonly IBaseDbService<ProductEntity> _dbContext;
        private readonly IMapper _mapper;

        public FeaturedProductsViewComponent(IBaseDbService<ProductEntity> context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productList = await _dbContext.GetAllIncludingAsync(
                p => p.Images,
                p => p.Category,
                p => p.Discount);
            var products = productList
                .Where(p => p.Enabled)
                .Select(p => _mapper.Map<FeaturedProductViewModel>(p))
                .ToList();

            return View(products);
        }
    }
}
