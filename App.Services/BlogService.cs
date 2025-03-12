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
    public class BlogService : IBlogService
    {
        private readonly IGenericRepository<BlogEntity> _blogService;
        public BlogService(IGenericRepository<BlogEntity> genericRepository)
        {
            _blogService = genericRepository;
        }

        public async Task AddBlog(BlogEntity blog)
        {
            await _blogService.Add(blog);
        }

        public async Task DeleteBlog(int id)
        {
            await _blogService.Delete(id);
        }

        public async Task<IEnumerable<BlogEntity>> GetAllBlog()
        {
            return await _blogService.GetAll();
        }

        public async Task<BlogEntity> GetBlogById(int id)
        {
            return await _blogService.GetById(id);
        }

        public async Task UpdateBlog(BlogEntity blog)
        {
            await _blogService.Update(blog);
        }
    }
}
