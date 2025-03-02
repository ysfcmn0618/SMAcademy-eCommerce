using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices.MyEntityInterfacess
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemEntity>> GetAllOrderItems();
        Task<OrderItemEntity> GetOrderItemById(int id);
        Task AddOrderItem(OrderItemEntity orderItem);
        Task UpdateOrderItem(OrderItemEntity orderItem);
        Task DeleteOrderItem(int id);
    }
}
