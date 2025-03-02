using App.Data.Entities;

namespace App.DbServices.MyEntityInterfacess
{
     interface IProductService
    {
        Task<IEnumerable<ProductEntity>> GetAllProducts();
        Task<ProductEntity> GetProductById(int id);
        Task AddProduct(ProductEntity product);
        Task UpdateProduct(ProductEntity product);
        Task DeleteProduct(int id);
    }
}
