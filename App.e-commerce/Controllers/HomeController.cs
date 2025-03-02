using System.Diagnostics;
using App.Data.ECommerceDbContext;
using App.eCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.eCommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ECommerceDbContext _dbContext;
        public HomeController(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Anasayfa
        public IActionResult Index()
        {
            return View();
        }
        [Route("/about-us")]
        //Hakkımızda
        public IActionResult AboutUs() { return View(); }
        //İletişim
        [Route("/contact")]
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("/contact")]
        [HttpPost]
        public IActionResult Contact([FromForm] object newContactMessageModel)
        {
            return View();
        }

        [Route("/product/list")]
        [HttpGet]
        public IActionResult Listing()
        {
            return View();
        }

        [Route("/product/{productId:int}/details")]
        [HttpGet]
        public IActionResult ProductDetail([FromRoute] int productId)
        {
            return View();
        }


    }
}
