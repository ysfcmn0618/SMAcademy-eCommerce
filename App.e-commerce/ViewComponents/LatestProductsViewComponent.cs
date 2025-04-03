using App.Data.Entities;
using App.DbServices.MyEntityInterfacess;
using App.eCommerce.Models.ViewModels.ProductViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Eticaret.ViewComponents
{
    public class LatestProductsViewComponent : ViewComponent
    {
        private readonly IBaseDbService<ProductEntity> _dbContext;
        private readonly IMapper _mapper;

        public LatestProductsViewComponent(IBaseDbService<ProductEntity> context,IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var itemsProduct = await _dbContext.GetAll();
            var viewModel = new OwlCarouselViewModel
            {
                Title = "Latest Products",
                Items = itemsProduct
                    .Where(p => p.Enabled)
                    .OrderByDescending(p => p.CreatedAt)
                    .Take(6)
                    .Select(p => _mapper.Map<ProductListingViewModel>(p)).ToList()
            };

            return View(viewModel);
        }
    }
}
