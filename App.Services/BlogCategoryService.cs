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
    public class BlogCategoryService : IBlogCategoryService
    {
        private readonly IGenericRepository<BlogCategoryEntity> _blogCategoryService;
        public BlogCategoryService(IGenericRepository<BlogCategoryEntity> genericRepository)
        {
            _blogCategoryService = genericRepository;
        }
        public async Task AddBlogCategory(BlogCategoryEntity blogCategory)
        {
            await _blogCategoryService.Add(blogCategory);
        }

        public async Task DeleteBlogCategory(int id)
        {
            await _blogCategoryService.Delete(id);
        }

        public async Task<IEnumerable<BlogCategoryEntity>> GetBlogCategories()
        {
            return await _blogCategoryService.GetAll();
        }

        public async Task<BlogCategoryEntity> GetBlogCategoryById(int id)
        {
            return await _blogCategoryService.GetById(id);
        }

        public async Task UpdateBlogCategory(BlogCategoryEntity blogCategory)
        {
            await _blogCategoryService.Update(blogCategory);
        }
    }
}
