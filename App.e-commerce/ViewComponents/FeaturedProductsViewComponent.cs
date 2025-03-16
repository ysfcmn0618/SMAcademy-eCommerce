using App.Data.Entities;
using App.DbServices.MyEntityInterfacess;
using App.eCommerce.Models.ViewModels.ProductViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Eticaret.ViewComponents
{
    public class FeaturedProductsViewModel : ViewComponent
    {
        private readonly BaseDbService<ProductEntity> _dbContext;
        private readonly IMapper _mapper;

        public FeaturedProductsViewModel(BaseDbService<ProductEntity> context,IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productList = await _dbContext.GetAllIncludingAsync();
            var products = productList
                .Where(p => p.Enabled)
                .Select(p => _mapper.Map<FeaturedProductsViewModel>(p))                
                .ToList();

            return View(products);
        }
    }
}
