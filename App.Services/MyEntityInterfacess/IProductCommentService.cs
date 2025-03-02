using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices.MyEntityInterfacess
{
    interface IProductCommentService
    {
        Task<IEnumerable<ProductCommentEntity>> GetAllProductComments();
        Task<ProductCommentEntity> GetProductCommentById(int id);
        Task AddProductComment(ProductCommentEntity productComment);
        Task UpdateProductComment(ProductCommentEntity productComment);
        Task DeleteProductComment(int id);
    }
}
