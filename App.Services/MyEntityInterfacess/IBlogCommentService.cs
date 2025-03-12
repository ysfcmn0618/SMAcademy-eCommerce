using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices.MyEntityInterfacess
{
    public interface IBlogCommentService
    {

        Task AddBlogComment(BlogCommentEntity blogComment);
        Task<BlogCommentEntity> GetBlogCommentById(int id);
        Task<IEnumerable<BlogCommentEntity>> GetBlogComments();
        Task UpdateBlogComment(BlogCommentEntity blogComment);
        Task DeleteBlogCommentById(int id);

    }
}
