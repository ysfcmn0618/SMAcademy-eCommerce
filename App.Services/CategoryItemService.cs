using App.Data.Repository;
using App.DbServices.MyEntityInterfacess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices
{
    public class CategoryItemService : ICategoryItemService
    {
        private readonly IGenericRepository<CategoryItemEntity> _categoryItemRepository;
        public CategoryItemService(IGenericRepository<CategoryItemEntity> categoryItemRepository)
        {
            _categoryItemRepository = categoryItemRepository;
        }
        public async Task AddCategoryItem(CategoryItemEntity categoryItem)
        {
            await _categoryItemRepository.Add(categoryItem);
        }

        public async Task DeleteCategoryItem(int id)
        {
           await _categoryItemRepository.Delete(id);
        }

        public async Task<IEnumerable<CategoryItemEntity>> GetAllCategoryItems()
        {
           return await _categoryItemRepository.GetAll();
        }

        public async Task<CategoryItemEntity> GetCategoryItemById(int id)
        {
           return await _categoryItemRepository.GetById(id);
        }

        public async Task UpdateCategoryItem(CategoryItemEntity categoryItem)
        {
            await _categoryItemRepository.Update(categoryItem);
        }
    }
}
