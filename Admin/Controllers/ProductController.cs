using App.Admin.Models.ProductViewModels;
using App.Data.Entities;
using App.Data.MyDbContext;
using App.DbServices;
using App.DbServices.MyEntityInterfacess;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace App.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly BaseDbService<ProductEntity> _productService;
        private readonly IMapper _mapper;

        public ProductController(BaseDbService<ProductEntity> productService,IMapper mapper)
        {
            _productService = productService;
            _mapper= mapper;
        }
        [Route("/products/")]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var products=await _productService.GetAll();

            return View(_mapper.Map<IEnumerable<ProductModel>>(products));
        }

        [Route("/products/filter")]
        [HttpGet]
        public IActionResult Filter([FromQuery] object filterOptions)
        {
            // will return filtered products as json
            return Json(new { });
        }

        [Route("/products/{productId:int}/delete")]
        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int productId)
        {
            await _productService.Delete(productId);
            return RedirectToAction(nameof(List),"Product");
        }
        [Route("/products/{productId:int}/edit")]
        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int productId)
        {
            var product = await _productService.GetById(productId);
            return View(_mapper.Map<ProductEditModel>(product));
        }
        [Route("/products/{productId:int}/edit")]
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int productId, [FromForm] ProductEditModel product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            //var existingProduct = await _productService.GetProductById(productId);
            //if (existingProduct is null)
            //{
            //    return NotFound();
            //}
            var productEntity = _mapper.Map<ProductEntity>(product);
            await _productService.Update(productEntity);
            return RedirectToAction(nameof(List),"Product");
        }

    }
}
