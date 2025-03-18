using App.Data.Entities;
using App.DbServices;
using App.DbServices.MyEntityInterfacess;
using App.eCommerce.Models.ViewModels.ProductViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace App.Eticaret.ViewComponents
{
    public class TopRatedProductsViewComponent : ViewComponent
    {
        private readonly BaseDbService<ProductEntity> _dbContext;
        private readonly IMapper _mapper;

        public TopRatedProductsViewComponent(ProductService context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModels = await _dbContext.GetAllIncludingAsync(p=>p.Comments);
            var viewModel = new OwlCarouselViewModel
            {
                Title = "Top Rated Products",
                Items = viewModels
                    .Where(p => p.Enabled)
                    .OrderByDescending(p => p.Comments.Any() ? p.Comments.Average(c => c.StarCount) : 0)
                    .Take(6)
                    .Select(p => _mapper.Map<ProductListingViewModel>(p))
                    .ToList()
            };

            return View(viewModel);
        }
    }
}
