using App.Data.Entities;
using App.Data.Repository;
using App.DbServices.MyEntityInterfacess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IGenericRepository<ProductCategoryEntity> _productCategoryRepository;
        public ProductCategoryService(IGenericRepository<ProductCategoryEntity> productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        public async Task AddProductCategory(ProductCategoryEntity productCategory)
        {
            await _productCategoryRepository.Add(productCategory);
        }

        public async Task DeleteProductCategory(int id)
        {
            await _productCategoryRepository.Delete(id);
        }

        public async Task<IEnumerable<ProductCategoryEntity>> GetAllProductCategories()
        {
            return await _productCategoryRepository.GetAll();
        }

        public async Task<ProductCategoryEntity> GetProductCategoryById(int id)
        {
            return await _productCategoryRepository.GetById(id);
        }

        public async Task UpdateProductCategory(ProductCategoryEntity productCategory)
        {
            await _productCategoryRepository.Update(productCategory);
        }
    }
}
