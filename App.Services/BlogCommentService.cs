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
    public class BlogCommentService : IBlogCommentService
    {
        private readonly IGenericRepository<BlogCommentEntity> _blogCommentService;

        public BlogCommentService(IGenericRepository<BlogCommentEntity> genericRepository)
        {
            _blogCommentService = genericRepository;
        }

        public async Task AddBlogComment(BlogCommentEntity blogComment)
        {
            await _blogCommentService.Add(blogComment);
        }

        public async Task DeleteBlogCommentById(int id)
        {
            await _blogCommentService.Delete(id);
        }

        public async Task<BlogCommentEntity> GetBlogCommentById(int id)
        {
            return await _blogCommentService.GetById(id);
        }

        public async Task<IEnumerable<BlogCommentEntity>> GetBlogComments()
        {
            return await _blogCommentService.GetAll();
        }

        public async Task UpdateBlogComment(BlogCommentEntity blogComment)
        {
            await _blogCommentService.Update(blogComment);
        }
    }
}
