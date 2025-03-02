using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices.MyEntityInterfacess
{
    interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategoryEntity>> GetAllProductCategories();
        Task<ProductCategoryEntity> GetProductCategoryById(int id);
        Task AddProductCategory(ProductCategoryEntity productCategory);
        Task UpdateProductCategory(ProductCategoryEntity productCategory);
        Task DeleteProductCategory(int id);
    }
}
