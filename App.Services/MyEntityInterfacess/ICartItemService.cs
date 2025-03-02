using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbServices.MyEntityInterfacess
{
    public interface ICartItemService
    {
        Task AddCartItem(CartItemEntity cartItem);
        Task<CartItemEntity> GetCartItem(int id);
        Task<List<CartItemEntity>> GetCartItems();
        Task UpdateCartItem(CartItemEntity cartItem);
        Task DeleteCartItem(int id);
    }
}
