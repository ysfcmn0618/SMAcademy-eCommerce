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
    public class OrderItemService : BaseDbService<OrderItemEntity>
    {
        private readonly IGenericRepository<OrderItemEntity> _orderItemRepository;
        public OrderItemService(IGenericRepository<OrderItemEntity> orderItemRepository) : base(orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }
       
        public async Task<IEnumerable<OrderItemEntity?>> GetOrderItemWithDetailsAsync()
        {
            return await _orderItemRepository.GetAllIncludingAsync(
                p => p.Order,
                p => p.Product
            );
        }

    }
}
