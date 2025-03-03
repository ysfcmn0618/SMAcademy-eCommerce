using App.Data.MyDbContext;
using App.DbServices.MyEntityInterfacess;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace App.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Route("/categories")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var categories = await _categoryService.GetAllCategories();
            return View(categories);
        }

        [Route("/categories/create")]
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [Route("/categories/create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] object newCategoryModel)
        {
           //await _categoryService.AddCategory(newCategoryModel);
            return View();
        }

        [Route("/categories/{categoryId:int}/edit")]
        [HttpGet]
        public IActionResult Edit([FromRoute] int categoryId)
        {
            return View();
        }

        [Route("/categories/{categoryId:int}/edit")]
        [HttpPost]
        public IActionResult Edit([FromRoute] int categoryId, [FromForm] object editCategoryModel)
        {
            return View();
        }

        [Route("/categories/{categoryId:int}/delete")]
        [HttpGet]
        public IActionResult Delete([FromRoute] int categoryId)
        {
            // delete actions
            return RedirectToAction("Index", "Home");
        }
    }
}
