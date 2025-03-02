using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices.MyEntityInterfacess
{
    interface IOrderService
    {
        Task<IEnumerable<OrderEntity>> GetAllOrders();
        Task<OrderEntity> GetOrderById(int id);
        Task AddOrder(OrderEntity order);
        Task UpdateOrder(OrderEntity order);
        Task DeleteOrder(int id);
    }
}
