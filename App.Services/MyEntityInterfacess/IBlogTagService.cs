using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices.MyEntityInterfacess
{
    public interface IBlogTagService
    {
        Task AddBlogTag(BlogTagEntity blogTag);
        Task<BlogTagEntity> GetBlogTagById(int id);
        Task<IEnumerable<BlogTagEntity>> GetBlogTags();
        Task UpdateBlogTag(BlogTagEntity blogTag);
        Task DeleteBlogTagById(int id);
    }
}
