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
    public class ProductService : BaseDbService<ProductEntity>
    {
        private readonly IGenericRepository<ProductEntity> _productRepository;
        public ProductService(IGenericRepository<ProductEntity> productRepository):base(productRepository)
        {
            _productRepository = productRepository;
        }      
        public async Task<IEnumerable<ProductEntity?>> GetProductsWithDetailsAsync()
        {
            return await _productRepository.GetAllIncludingAsync(
                p => p.Category,           // Kategori bilgilerini de al
                p => p.Seller,        // Satıcı detaylarını da al
                p => p.Discount,         //indirim detaylarını da al 
                p=> p.Images,
                p=>p.Comments
            );
        }

        public async Task<ProductEntity?> GetProductByIdWithDetailsAsync(int id)
        {
            return await _productRepository.GetByIdIncludingAsync(
                id,
                p => p.Category,           // Kategori bilgilerini de al
                p => p.Seller,        // Satıcı detaylarını da al
                p => p.Discount,         //indirim detaylarını da al 
                p => p.Images,
                p => p.Comments
            );
        }
    }
}
