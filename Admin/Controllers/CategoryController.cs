using App.Admin.Mapping;
using App.Admin.Models.CategoryViewModels;
using App.Data.Entities;
using App.Data.MyDbContext;
using App.DbServices.MyEntityInterfacess;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace App.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BaseDbService<CategoryEntity> _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(BaseDbService<CategoryEntity> categoryService, IMapper mappingProfile)
        {
            _categoryService = categoryService;
            _mapper = mappingProfile;
        }
        [Route("/categories")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var categories = await _categoryService.GetAll();

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
            await _categoryService.Add(category);
            return RedirectToAction(nameof(List), "Category");
        }

        [Route("/categories/{categoryId:int}/edit")]
        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int categoryId)
        {
            var category = await _categoryService.GetById(categoryId);
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
            var category = await _categoryService.GetById(categoryId);
            if (category is null)
            {
                return NotFound();
            }
            var updatedCategory = _mapper.Map(editCategoryModel, category);
            await _categoryService.Update(updatedCategory);
            return RedirectToAction(nameof(List), "Category");
        }

        [Route("/categories/{categoryId:int}/delete")]
        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int categoryId)
        {
            try
            {
                await _categoryService.Delete(categoryId);
            }
            catch (DbUpdateException)
            {
                ViewBag.ErrorMessage = "Bu kategori başka bir üründe kullanılıyor.";
                return RedirectToAction(nameof(List), "Category");
            }
            catch (InvalidOperationException)
            {
                ViewBag.ErrorMessage = "Geçersiz işlem yapıldı.";
                return RedirectToAction(nameof(List), "Category");
            }

            return RedirectToAction(nameof(List), "Category");
        }
    }
}
