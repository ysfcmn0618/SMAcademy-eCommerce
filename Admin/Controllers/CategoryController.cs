using App.Admin.Mapping;
using App.Admin.Models.CategoryViewModels;
using App.Data.Entities;
using App.Data.MyDbContext;
using App.DbServices.MyEntityInterfacess;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace App.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mappingProfile)
        {
            _categoryService = categoryService;
            _mapper = mappingProfile;
        }
        [Route("/categories")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var categories = await _categoryService.GetAllCategories();

            return View(_mapper.Map<IEnumerable<CategoryModel>>(categories));
        }

        [Route("/categories/create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("/categories/create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryModel newCategoryModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var category = _mapper.Map<CategoryEntity>(newCategoryModel);
            await _categoryService.AddCategory(category);
            return RedirectToAction(nameof(List), "Category");
        }

        [Route("/categories/{categoryId:int}/edit")]
        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int categoryId)
        {
            var category = await _categoryService.GetCategoryById(categoryId);
            return View(_mapper.Map<CategoryModel>(category));
        }

        [Route("/categories/{categoryId:int}/edit")]
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int categoryId, [FromForm] CategoryModel editCategoryModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var category = await _categoryService.GetCategoryById(categoryId);
            if (category is null)
            {
                return NotFound();
            }
            var updatedCategory = _mapper.Map(editCategoryModel, category);
            await _categoryService.UpdateCategory(updatedCategory);
            return RedirectToAction(nameof(List),"Category");
        }

        [Route("/categories/{categoryId:int}/delete")]
        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int categoryId)
        {
            await _categoryService.DeleteCategory(categoryId);
            return RedirectToAction(nameof(List), "Category");
        }
    }
}
