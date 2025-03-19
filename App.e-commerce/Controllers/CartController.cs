using App.Data.MyDbContext;
using App.Eticaret.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace App.eCommerce.Controllers
{
    public class CartController : BaseController
    {
        private readonly ECommerceDbContext _dbContext;
        public CartController(ECommerceDbContext dbcontext)
        {
            _dbContext= dbcontext;
        }
        [Route("/add-to-cart/{productId:int}")]
        [HttpGet]
        public IActionResult AddProduct([FromRoute] int productId)
        {
            // add 1 product...

            var prevUrl = Request.Headers.Referer.FirstOrDefault();

            if (prevUrl is null)
            {
                return RedirectToAction(nameof(Edit));
            }

            return Redirect(prevUrl);
        }

        [Route("/cart")]
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [Route("/cart")]
        [HttpPost]
        public IActionResult Edit([FromForm] object editCartModel)
        {
            return View();
        }
    }
}
