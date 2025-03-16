﻿using App.Data.Entities;
using App.Data.Repository;
using App.DbServices.MyEntityInterfacess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<ProductEntity> _productRepository;
        public ProductService(IGenericRepository<ProductEntity> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task AddProduct(ProductEntity product)
        {
            await _productRepository.Add(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.Delete(id);
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProducts()
        {
            return await _productRepository.GetAll();
        }

        public async Task<ProductEntity> GetProductById(int id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task UpdateProduct(ProductEntity product)
        {
            await _productRepository.Update(product);
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
