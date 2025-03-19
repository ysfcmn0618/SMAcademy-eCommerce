using System.Diagnostics;
using App.Data.MyDbContext;
using App.eCommerce.Models;
using App.Eticaret.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace App.eCommerce.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ECommerceDbContext _dbContext;
        public HomeController(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Anasayfa
        public IActionResult Index()
        {
            ViewData["ActivePage"] = "Index";
            return View();
        }
        [Route("/about-us")]
        //Hakkımızda
        public IActionResult AboutUs()
        {
            ViewData["ActivePage"] = "AboutUs";
            return View();
        }
        //İletişim
        [Route("/contact")]
        [HttpGet]
        public IActionResult Contact()
        {
            ViewData["ActivePage"] = "Contact";
            return View();
        }

        [Route("/contact")]
        [HttpPost]
        public IActionResult Contact([FromForm] object newContactMessageModel)
        {
            ViewData["ActivePage"] = "Contact";
            return View();
        }

        [Route("/product/list")]
        [HttpGet]
        public IActionResult Listing()
        {
            ViewData["ActivePage"] = "Listing";
            return View();
        }

        [Route("/product/{productId:int}/details")]
        [HttpGet]
        public IActionResult ProductDetail([FromRoute] int productId)
        {
            ViewData["ActivePage"] = "ProductDetail";
            return View();
        }


    }
}
