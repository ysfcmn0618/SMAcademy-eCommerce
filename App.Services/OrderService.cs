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
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<OrderEntity> _orderRepository;
        public OrderService(IGenericRepository<OrderEntity> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task AddOrder(OrderEntity orderItem)
        {
            await _orderRepository.Add(orderItem);
        }

        public async Task DeleteOrder(int id)
        {
            await _orderRepository.Delete(id);
        }

        public async Task<IEnumerable<OrderEntity>> GetAllOrders()
        {
            return await _orderRepository.GetAll();
        }

        public async Task<OrderEntity> GetOrderById(int id)
        {
            return await _orderRepository.GetById(id);
        }

        public async Task UpdateOrder(OrderEntity orderItem)
        {
            await _orderRepository.Update(orderItem);
        }
        public async Task<IEnumerable<OrderEntity?>> GetOrderWithDetailsAsync()
        {
            return await _orderRepository.GetAllIncludingAsync(
                p => p.User
            );
        }

    }
}
