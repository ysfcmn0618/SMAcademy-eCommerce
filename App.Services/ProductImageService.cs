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
    public class ProductImageService : IProductImageService
    {
        private readonly IGenericRepository<ProductImageEntity> _productImageRepository;
        public ProductImageService(IGenericRepository<ProductImageEntity> productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }
        public async Task AddProductImage(ProductImageEntity productImage)
        {
            await _productImageRepository.Add(productImage);
        }

        public async Task DeleteProductImage(int id)
        {
            await _productImageRepository.Delete(id);
        }

        public async Task<IEnumerable<ProductImageEntity>> GetAllProductImages()
        {
            return await _productImageRepository.GetAll();
        }

        public async Task<ProductImageEntity> GetProductImageById(int id)
        {
            return await _productImageRepository.GetById(id);
        }

        public async Task UpdateProductImage(ProductImageEntity productImage)
        {
            await _productImageRepository.Update(productImage);
        }
    }
}
