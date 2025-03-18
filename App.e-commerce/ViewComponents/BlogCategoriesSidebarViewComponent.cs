using App.Data.Entities;
using App.DbServices.MyEntityInterfacess;
using App.eCommerce.Models.ViewModels.BlogViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.eCommerce.ViewComponents
{
    public class BlogCategoriesSidebarViewComponent : ViewComponent
    {
        private readonly BaseDbService<BlogCategoryEntity> _dbContext;
        private readonly IMapper _mapper;

        public BlogCategoriesSidebarViewComponent(BaseDbService<BlogCategoryEntity> baseDb,IMapper mapper)
        {
            _dbContext = baseDb;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var modelDb = await _dbContext.GetAllIncludingAsync(p => p.BlogRelations);
            var model = modelDb.Select(c => _mapper.Map<BlogCategorySidebarViewModel>(c)).ToList();
            return View(model);
        }
    }
}
