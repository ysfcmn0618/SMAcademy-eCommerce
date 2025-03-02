using App.Data.ECommerceDbContext;
using Microsoft.AspNetCore.Mvc;

namespace App.eCommerce.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ECommerceDbContext _dbContext;
        public ProfileController(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Route("/profile")]
        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }

        [Route("/profile")]
        [HttpPost]
        public IActionResult Edit([FromForm] object editMyProfileModel)
        {
            return RedirectToAction(nameof(Details));
        }

        [Route("/my-orders")]
        [HttpGet]
        public IActionResult MyOrders()
        {
            return View();
        }

        [Route("/my-products")]
        [HttpGet]
        public IActionResult MyProducts()
        {
            return View();
        }
    }
}
