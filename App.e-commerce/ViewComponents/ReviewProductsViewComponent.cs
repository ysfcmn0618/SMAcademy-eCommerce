using App.Data.Entities;
using App.DbServices.MyEntityInterfacess;
using App.eCommerce.Models.ViewModels.ProductViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Eticaret.ViewComponents
{
    public class ReviewProductsViewComponent : ViewComponent
    {
        private readonly BaseDbService<ProductEntity> _dbContext;
        private readonly IMapper _mapper;

        public ReviewProductsViewComponent(BaseDbService<ProductEntity> context,IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModels = await _dbContext.GetAllIncludingAsync();
            var viewModel = new OwlCarouselViewModel
            {
                Title = "Review Products",
                Items = viewModels
                    .Where(p => p.Enabled)
                    .OrderByDescending(p => p.Comments.Count)
                    .Take(6)
                    .Select(p => _mapper.Map<ProductListingViewModel>(p))
                    .ToList()
            };

            //        .Select(p => new ProductListingViewModel
            //        {
            //            Id = p.Id,
            //            Name = p.Name,
            //            Price = p.Price,
            //            CategoryName = p.Category.Name,
            //            DiscountPercentage = p.Discount == null ? null : p.Discount.DiscountRate,
            //            ImageUrl = p.Images.Count != 0 ? p.Images.First().Url : null
            //        })
            //        .ToListAsync()
            //};
           

            return View(viewModel);
        }
    }
}
