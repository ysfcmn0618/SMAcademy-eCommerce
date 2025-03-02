using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices.MyEntityInterfacess
{
    interface IProductImageService
    {
        Task<IEnumerable<ProductImageEntity>> GetAllProductImages();
        Task<ProductImageEntity> GetProductImageById(int id);
        Task AddProductImage(ProductImageEntity productImage);
        Task UpdateProductImage(ProductImageEntity productImage);
        Task DeleteProductImage(int id);
    }
}
