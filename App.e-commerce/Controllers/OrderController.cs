using App.Data.Entities;
using App.Data.Infrastructure.MyDbContext;
using App.DbServices.MyEntityInterfacess;
using App.eCommerce.Models.ViewModels.CartItemViewModel;
using App.eCommerce.Models.ViewModels.OrderViewModels;
using App.Eticaret.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.eCommerce.Controllers
{
    public class OrderController(ECommerceDbContext _dbContext, IMapper _mapper) : BaseController
    {
       
        [Route("/order")]
        [HttpPost]
        //Sipariş Oluşturma
        public async Task<IActionResult> Create([FromForm] CheckoutViewModel model)
        {
            var userId = GetUserId();

            if (userId is null)
            {
                return RedirectToAction(nameof(AuthController.Login), "Auth");
            }
            if (!ModelState.IsValid)
            {
                var viewModel = await GetCartItemsAsync();
                return View(viewModel);
            }
            var cartItems = await _dbContext.CartItems
                 .Include(ci => ci.Product)
                 .Where(ci => ci.UserId == userId)
                 .ToListAsync();
            if (cartItems.Count() == 0)
            {
                return RedirectToAction(nameof(CartController.Edit), "Cart");
            }
            var order = new OrderEntity
            {
                UserId = userId.Value,
                Address = model.Address,
                OrderCode = CreateOrderCode(),
                CreatedAt = DateTime.UtcNow
            };
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            foreach (var cartItem in cartItems)
            {
                var orderItem = new OrderItemEntity
                {
                    OrderId = order.Id,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Product.Price,
                    CreatedAt = DateTime.UtcNow,
                };

                _dbContext.OrderItems.Add(orderItem);
                _dbContext.CartItems.Remove(cartItem);
            }
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { orderCode = order.OrderCode });
        }
        [Route("/order/{id:int}/details")]
        [HttpGet]
        //Sipariş Detayları
        public async Task<IActionResult> Details([FromRoute] string orderCode) {
            var userId = GetUserId();

            if (userId is null)
            {
                return RedirectToAction(nameof(AuthController.Login), "Auth");
            }
            var order = await _dbContext.Orders
               .Where(o => o.UserId == userId && o.OrderCode == orderCode)
               .Select(o => new OrderDetailsViewModel
               {
                   OrderCode = o.OrderCode,
                   CreatedAt = o.CreatedAt,
                   Address = o.Address,
                   Items = o.OrderItems.Select(oi => new OrderItemViewModel
                   {
                       ProductName = oi.Product.Name,
                       Quantity = oi.Quantity,
                       UnitPrice = oi.UnitPrice,
                   }).ToList()
               })
               .FirstOrDefaultAsync();
            if (order is null)
            {
                return NotFound();
            }

            return View(order);
        }

        private string CreateOrderCode()
        {
            return Guid.NewGuid().ToString("n")[..16].ToUpperInvariant();
        }
        private async Task<List<CartItemViewModel>> GetCartItemsAsync()
        {
            var userId = GetUserId() ?? -1;
            //var cartItems = await _dbContext.GetAllIncludingAsync(p=>p.Product.Images,p=>p.Product);
            //var itemsMap = _mapper.Map<IEnumerable<CartItemViewModel>>(cartItems).ToList();
            //return itemsMap;
            return await _dbContext.CartItems
                .Include(ci => ci.Product.Images)
                .Where(ci => ci.UserId == userId)
                .Select(ci => new CartItemViewModel
                {
                    Id = ci.Id,
                    ProductName = ci.Product.Name,
                    ProductImage = ci.Product.Images.Count != 0 ? ci.Product.Images.First().Url : null,
                    Quantity = ci.Quantity,
                    Price = ci.Product.Price
                })
                .ToListAsync();
        }
    }
}
