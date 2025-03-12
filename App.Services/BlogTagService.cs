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
    public class BlogTagService : IBlogTagService
    {
        private readonly IGenericRepository<BlogTagEntity> _blogTagService;
        public BlogTagService(IGenericRepository<BlogTagEntity> genericRepository)
        {
            _blogTagService = genericRepository;
        }
        public async Task AddBlogTag(BlogTagEntity blogTag)
        {
            await _blogTagService.Add(blogTag);
        }

        public async Task DeleteBlogTagById(int id)
        {
            await _blogTagService.Delete(id);
        }

        public async Task<BlogTagEntity> GetBlogTagById(int id)
        {
            return await _blogTagService.GetById(id);
        }

        public async Task<IEnumerable<BlogTagEntity>> GetBlogTags()
        {
            return await _blogTagService.GetAll();
        }

        public async Task UpdateBlogTag(BlogTagEntity blogTag)
        {
            await _blogTagService.Update(blogTag);
        }
    }
}
