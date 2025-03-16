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
    public class OrderService : BaseDbService<OrderEntity>
    {
        private readonly IGenericRepository<OrderEntity> _orderRepository;
        public OrderService(IGenericRepository<OrderEntity> orderRepository):base(orderRepository)
        {
            _orderRepository = orderRepository;
        }
       
        public async Task<IEnumerable<OrderEntity?>> GetOrderWithDetailsAsync()
        {
            return await _orderRepository.GetAllIncludingAsync(
                p => p.User
            );
        }

    }
}
