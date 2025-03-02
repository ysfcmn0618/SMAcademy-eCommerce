using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices.MyEntityInterfacess
{
    interface ICategoryItemService
    {
        Task<IEnumerable<CategoryItemEntity>> GetAllCategoryItems();
        Task<CategoryItemEntity> GetCategoryItemById(int id);
        Task AddCategoryItem(CategoryItemEntity categoryItem);
        Task UpdateCategoryItem(CategoryItemEntity categoryItem);
        Task DeleteCategoryItem(int id);
    }
}
