using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices.MyEntityInterfacess
{
    public interface IBlogCategoryService
    {
        Task AddBlogCategory(BlogCategoryEntity blogCategory);
        Task<BlogCategoryEntity> GetBlogCategoryById(int id);
        Task<IEnumerable<BlogCategoryEntity>> GetBlogCategories();
        Task UpdateBlogCategory(BlogCategoryEntity blogCategory);
        Task DeleteBlogCategory(int id);

    }
}
