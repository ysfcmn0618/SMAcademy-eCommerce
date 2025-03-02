using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices.MyEntityInterfacess
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryEntity>> GetAllCategories();
        Task<CategoryEntity> GetCategoryById(int id);
        Task AddCategory(CategoryEntity category);
        Task UpdateCategory(CategoryEntity category);
        Task DeleteCategory(int id);
    }
}
