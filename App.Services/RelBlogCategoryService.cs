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
    public class RelBlogCategoryService : IRelBlogCategoryService
    {
        private readonly IGenericRepository<RelBlogCategoryEntity> _relBlogCategoryService;
        public RelBlogCategoryService(IGenericRepository<RelBlogCategoryEntity> genericRepository)
        {
            _relBlogCategoryService = genericRepository;
        }
        public async Task AddRelBlogCategory(RelBlogCategoryEntity relBlogCategory)
        {
            await _relBlogCategoryService.Add(relBlogCategory);
        }

        public async Task DeleteRelBlogCategoryById(int id)
        {
            await _relBlogCategoryService.Delete(id);
        }

        public async Task<IEnumerable<RelBlogCategoryEntity>> GetRelBlogCategories()
        {
            return await _relBlogCategoryService.GetAll();
        }

        public async Task<RelBlogCategoryEntity> GetRelBlogCategoryById(int id)
        {
            return await _relBlogCategoryService.GetById(id);
        }

        public async Task UpdateRelBlogCategory(RelBlogCategoryEntity relBlogCategory)
        {
            await _relBlogCategoryService.Update(relBlogCategory);
        }
    }
}
