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
    class OrderItemService : IOrderItemService
    {
        private readonly IGenericRepository<OrderItemEntity> _orderItemRepository;
        public OrderItemService(IGenericRepository<OrderItemEntity> orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }
        public async Task AddOrderItem(OrderItemEntity orderItem)
        {
            await _orderItemRepository.Add(orderItem);
        }

        public async Task DeleteOrderItem(int id)
        {
            await _orderItemRepository.Delete(id);
        }

        public async Task<IEnumerable<OrderItemEntity>> GetAllOrderItems()
        {
            return await _orderItemRepository.GetAll();
        }

        public async Task<OrderItemEntity> GetOrderItemById(int id)
        {
            return await _orderItemRepository.GetById(id);
        }

        public async Task UpdateOrderItem(OrderItemEntity orderItem)
        {
            await _orderItemRepository.Update(orderItem);
        }
    }
}
