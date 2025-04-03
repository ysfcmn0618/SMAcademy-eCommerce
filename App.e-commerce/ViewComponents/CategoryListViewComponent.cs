using App.Data.Entities;
using App.DbServices.MyEntityInterfacess;
using App.eCommerce.Models.ViewModels.CategoryViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Eticaret.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly IBaseDbService<CategoryEntity> _context;
        private readonly IMapper _mapper;

        public CategoryListViewComponent(IBaseDbService<CategoryEntity> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoriesAll = await _context.GetAll();
            var categories = categoriesAll
                .Select(c => _mapper.Map<CategoryListViewModel>(c)).ToList();
            return View(categories);
        }
    }
}
