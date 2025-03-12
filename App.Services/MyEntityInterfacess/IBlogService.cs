using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices.MyEntityInterfacess
{
    public interface IBlogService
    {
        Task AddBlog(BlogEntity blog);
        Task<BlogEntity> GetBlogById(int id);
        Task<IEnumerable<BlogEntity>> GetAllBlog();
        Task UpdateBlog(BlogEntity blog);
        Task DeleteBlog(int id);
    }
}
