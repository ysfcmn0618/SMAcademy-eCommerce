using App.Data.Entities;
using App.DbServices.MyEntityInterfacess;
using App.eCommerce.Models.ViewModels.BlogViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Eticaret.ViewComponents
{
    public class FromTheBlogViewComponent : ViewComponent
    {
        private readonly IBaseDbService<BlogEntity> _dbContext;
        private readonly IMapper _mapper;

        public FromTheBlogViewComponent(IBaseDbService<BlogEntity> context,IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = await _dbContext.GetAllIncludingAsync(p=>p.Comments);
            var model = viewModel.Where(e => e.Enabled)
                    .OrderByDescending(e => e.CreatedAt)
                    .Take(3)
                    .Select(e => _mapper.Map<BlogSummaryViewModel>(e))
                    .ToList();
            return View(model);
        }
    }
}
