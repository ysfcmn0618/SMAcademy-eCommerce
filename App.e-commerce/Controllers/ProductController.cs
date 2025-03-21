using App.Data.Entities;
using App.Data.MyDbContext;
using App.eCommerce.Models.ViewModels.ProductViewModels;
using App.Eticaret.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.eCommerce.Controllers
{
    [Route("/product")]
    public class ProductController : BaseController
    {
        private readonly ECommerceDbContext _dbContext;
        public ProductController(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm] SaveProductViewModel newProductModel)
        {

            if (!ModelState.IsValid)
            {
                return View(newProductModel);
            }

            var productEntity = new ProductEntity
            {
                SellerId = 2, // TODO: User'ı al
                CategoryId = newProductModel.CategoryId,
                DiscountId = newProductModel.DiscountId,
                Name = newProductModel.Name,
                Price = newProductModel.Price,
                Description = newProductModel.Description,
                StockAmount = newProductModel.StockAmount,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Products.Add(productEntity);
            await _dbContext.SaveChangesAsync();

            await SaveProductImages(productEntity.Id, newProductModel.Images);

            ViewBag.SuccessMessage = "Ürün başarıyla eklendi.";
            ModelState.Clear();

            return View();
        }

        [HttpGet("{productId:int}/edit")]
        public async Task<IActionResult> Edit([FromRoute] int productId)
        {
            var productEntity = await _dbContext.Products.FindAsync(productId);
            if (productEntity is null)
            {
                return NotFound();
            }

            var viewModel = new SaveProductViewModel
            {
                CategoryId = productEntity.CategoryId,
                DiscountId = productEntity.DiscountId,
                Name = productEntity.Name,
                Price = productEntity.Price,
                Description = productEntity.Description,
                StockAmount = productEntity.StockAmount
            };

            return View(viewModel);
        }

        [HttpPost("{productId:int}/edit")]
        public async Task<IActionResult> Edit([FromRoute] int productId, [FromForm] SaveProductViewModel editProductModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editProductModel);
            }

            var productEntity = await _dbContext.Products.FindAsync(productId);

            if (productEntity is null)
            {
                return NotFound();
            }

            productEntity.CategoryId = editProductModel.CategoryId;
            productEntity.DiscountId = editProductModel.DiscountId;
            productEntity.Name = editProductModel.Name;
            productEntity.Price = editProductModel.Price;
            productEntity.Description = editProductModel.Description;
            productEntity.StockAmount = editProductModel.StockAmount;

            await _dbContext.SaveChangesAsync();

            ViewBag.SuccessMessage = "Ürün başarıyla güncellendi.";

            return View(editProductModel);
        }

        [HttpGet("{productId:int}/delete")]
        public async Task<IActionResult> Delete([FromRoute] int productId)
        {
            var productEntity = await _dbContext.Products.FindAsync(productId);
            if (productEntity is null)
            {
                return NotFound();
            }

            _dbContext.Products.Remove(productEntity);
            await _dbContext.SaveChangesAsync();

            ViewBag.SuccessMessage = "Ürün başarıyla silindi.";

            return View();
        }

        [HttpPost("{productId:int}/comment")]
        public async Task<IActionResult> Comment([FromRoute] int productId, [FromForm] SaveProductCommentViewModel newProductCommentModel)
        {
            var userId = GetUserId();

            if (userId == null)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await _dbContext.Products.AnyAsync(x => x.Id == productId))
            {
                return NotFound();
            }

            if (await _dbContext.ProductComments.AnyAsync(x => x.ProductId == productId && x.UserId == userId))
            {
                return BadRequest();
            }

            var productCommentEntity = new ProductCommentEntity
            {
                ProductId = productId,
                UserId = userId.Value,
                Text = newProductCommentModel.Text,
                StarCount = newProductCommentModel.StarCount,
                CreatedAt = DateTime.UtcNow,
            };

            _dbContext.ProductComments.Add(productCommentEntity);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
        private async Task SaveProductImages(int productId, IList<IFormFile> images)
        {
            foreach (var image in images)
            {
                var productImageEntity = new ProductImageEntity
                {
                    ProductId = productId,
                    Url = $"/uploads/{Guid.NewGuid()}{Path.GetExtension(image.FileName)}"
                };

                _dbContext.ProductImages.Add(productImageEntity);
                await _dbContext.SaveChangesAsync();

                await using var fileStream = new FileStream($"wwwroot{productImageEntity.Url}", FileMode.Create);
                await image.CopyToAsync(fileStream);
            }
        }
    }
}
