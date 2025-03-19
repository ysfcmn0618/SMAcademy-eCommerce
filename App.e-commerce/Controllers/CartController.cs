using App.Data.Entities;
using App.Data.MyDbContext;
using App.DbServices.MyEntityInterfacess;
using App.eCommerce.Models.ViewModels.CartItemViewModel;
using App.Eticaret.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace App.eCommerce.Controllers
{
    public class CartController : BaseController
    {
        private readonly BaseDbService<CartItemEntity> _dbContext;
        private readonly IMapper _mapper;

        public CartController(BaseDbService<CartItemEntity> dbcontext,IMapper mapper)
        {
            _dbContext= dbcontext;
            _mapper = mapper;
        }
        [Route("/add-to-cart/{productId:int}")]
        [HttpGet]
        public async Task<IActionResult> AddProduct([FromRoute] int productId)
        {
            // add 1 product...
            var userId = GetUserId();
            if (userId is null)
            {
                return RedirectToAction(nameof(AuthController.Login), "Auth");
            }
            var dbProducts = await _dbContext.GetAllIncludingAsync(p=>p.Product);
            var product = dbProducts.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                return NotFound();
            }
            var cartItem = await _dbContext.FirstOrDefaultAsync(ci => ci.UserId == userId && ci.ProductId == productId);

            if (cartItem is not null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cartItem = new CartItemEntity
                {
                    UserId = userId.Value,
                    ProductId = productId,
                    Quantity = 1,
                    CreatedAt = DateTime.UtcNow
                };

                await _dbContext.Add(cartItem);
            }

            var prevUrl = Request.Headers.Referer.FirstOrDefault();

            if (prevUrl is null)
            {
                return RedirectToAction(nameof(Edit));
            }


            return Redirect(prevUrl);
        }

        [HttpGet("/cart")]
        public async Task<IActionResult> Edit()
        {
            var userId = GetUserId();

            if (userId is null)
            {
                return RedirectToAction(nameof(AuthController.Login), "Auth");
            }

            List<CartItemViewModel> cartItem = await GetCartItemsAsync();

            return View(cartItem);
        }

        [HttpGet("/cart/{cartItemId:int}/remove")]
        public async Task<IActionResult> Remove([FromRoute] int cartItemId)
        {
            var userId = GetUserId();

            if (userId is null)
            {
                return RedirectToAction(nameof(AuthController.Login), "Auth");
            }

            var cartItem = await _dbContext.FirstOrDefaultAsync(ci => ci.UserId == userId && ci.Id == cartItemId);

            if (cartItem is null)
            {
                return NotFound();
            }

            await _dbContext.Delete(cartItem.Id);

            return RedirectToAction(nameof(Edit));
        }

        [HttpPost("/cart/update")]
        public async Task<IActionResult> UpdateCart(int cartItemId, byte quantity)
        {
            var userId = GetUserId();

            if (userId is null)
            {
                return RedirectToAction(nameof(AuthController.Login), "Auth");
            }
            var cartItems = await _dbContext.GetAllIncludingAsync(p=>p.Product.Images,propa=>propa.Product);
            var cartItem = cartItems
                .FirstOrDefault(ci => ci.UserId == userId && ci.Id == cartItemId);

            if (cartItem is null)
            {
                return NotFound();
            }

            cartItem.Quantity = quantity;

            var model = _mapper.Map<CartItemEntity>(cartItem);

            return View(model);
        }

        [HttpGet("/checkout")]
        public async Task<IActionResult> Checkout()
        {
            var userId = GetUserId();

            if (userId is null)
            {
                return RedirectToAction(nameof(AuthController.Login), "Auth");
            }

            List<CartItemViewModel> cartItems = await GetCartItemsAsync();

            return View(cartItems);
        }

        private async Task<List<CartItemViewModel>> GetCartItemsAsync()
        {
            var userId = GetUserId() ?? -1;
            var cartItems = await _dbContext.GetAllIncludingAsync(p => p.Product.Images, propa => propa.Product);
            var mappingCarts = _mapper.Map<IEnumerable<CartItemViewModel>>(cartItems).ToList();
            return mappingCarts;
        }
    }
}
