﻿using App.Data.Entities;
using App.DbServices.MyEntityInterfacess;
using App.eCommerce.Models.ViewModels.ProductViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Eticaret.ViewComponents
{
    public class ReviewProductsViewComponent : ViewComponent
    {
        private readonly IBaseDbService<ProductEntity> _dbContext;
        private readonly IMapper _mapper;

        public ReviewProductsViewComponent(IBaseDbService<ProductEntity> context,IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModels = await _dbContext.GetAllIncludingAsync(p=>p.Comments);
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
            return View(viewModel);
        }
    }
}
