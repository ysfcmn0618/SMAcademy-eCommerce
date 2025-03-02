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
    public class ProductCommentService : IProductCommentService
    {
        private readonly IGenericRepository<ProductCommentEntity> _productCommentRepository;
        public ProductCommentService(IGenericRepository<ProductCommentEntity> productCommentRepository)
        {
            _productCommentRepository = productCommentRepository;
        }
        public async Task AddProductComment(ProductCommentEntity productComment)
        {
            await _productCommentRepository.Add(productComment);
        }

        public async Task DeleteProductComment(int id)
        {
            await _productCommentRepository.Delete(id);
        }

        public async Task<IEnumerable<ProductCommentEntity>> GetAllProductComments()
        {
            return await _productCommentRepository.GetAll();
        }

        public async Task<ProductCommentEntity> GetProductCommentById(int id)
        {
            return await _productCommentRepository.GetById(id);
        }

        public async Task UpdateProductComment(ProductCommentEntity productComment)
        {
            await _productCommentRepository.Update(productComment);
        }
    }
}
