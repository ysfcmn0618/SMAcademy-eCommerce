using App.Data.Entities;
using App.DbServices.MyEntityInterfacess;
using App.Eticaret.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace App.eCommerce.Controllers
{
    public class BlogController : BaseController
    {
        private readonly BaseDbService<BlogEntity> _dbContext;

        public BlogController(BaseDbService<BlogEntity> dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("blog")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // TODO: remove comment after seeding data
            //var viewModel = await _dbContext.Blogs
            //    .Where(e => e.Enabled)
            //    .OrderByDescending(e => e.CreatedAt)
            //    .Take(6)
            //    .Select(e => new BlogSummaryViewModel
            //    {
            //        Id = e.Id,
            //        Title = e.Title,
            //        SummaryContent = e.Content.Substring(0, 100),
            //        ImageUrl = e.ImageUrl,
            //        CommentCount = e.Comments.Count,
            //        CreatedAt = e.CreatedAt
            //    })
            //    .ToListAsync();

            //return View(viewModel);

            return View();
        }

        [Route("blog/{id}")]
        [HttpGet]
        public IActionResult Detail(int id)
        {
            return View();
        }
    }
}
