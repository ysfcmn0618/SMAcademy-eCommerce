using App.Data.Entities;
using App.Data.Repository;
using App.DbServices.MyEntityInterfacess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<CategoryEntity> _categoryRepository;
        public CategoryService(IGenericRepository<CategoryEntity> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task AddCategory(CategoryEntity category)
        {
            await _categoryRepository.Add(category);
        }

        public async Task DeleteCategory(int id)
        {
            await _categoryRepository.Delete(id);
        }

        public async Task<IEnumerable<CategoryEntity>> GetAllCategories()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<CategoryEntity> GetCategoryById(int id)
        {
           return await _categoryRepository.GetById(id);
        }

        public async Task UpdateCategory(CategoryEntity category)
        {
            await _categoryRepository.Update(category);
        }
    }
}
