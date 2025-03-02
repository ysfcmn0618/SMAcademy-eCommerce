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
    public class CartItemService : ICartItemService
    {
        private readonly IGenericRepository<CartItemEntity> _cartItemRepository;
        public CartItemService(IGenericRepository<CartItemEntity> cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }
        public async Task AddCartItem(CartItemEntity cartItem)
        {
            await _cartItemRepository.Add(cartItem);
        }

        public async Task DeleteCartItem(int id)
        {
             await _cartItemRepository.Delete(id);
        }

        public async Task<CartItemEntity> GetCartItem(int id)
        {
            return await _cartItemRepository.GetById(id);
        }

        public async Task<List<CartItemEntity>> GetCartItems()
        {
            return (List<CartItemEntity>)await _cartItemRepository.GetAll();
        }

        public async Task UpdateCartItem(CartItemEntity cartItem)
        {
            await _cartItemRepository.Update(cartItem);
        }
    }
}
