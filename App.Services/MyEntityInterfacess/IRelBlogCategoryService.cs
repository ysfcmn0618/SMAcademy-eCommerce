using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices.MyEntityInterfacess
{
    public interface IRelBlogCategoryService
    {
        Task AddRelBlogCategory(RelBlogCategoryEntity relBlogCategory);
        Task<RelBlogCategoryEntity> GetRelBlogCategoryById(int id);
        Task<IEnumerable<RelBlogCategoryEntity>> GetRelBlogCategories();
        Task UpdateRelBlogCategory(RelBlogCategoryEntity relBlogCategory);
        Task DeleteRelBlogCategoryById(int id);
    }
}
