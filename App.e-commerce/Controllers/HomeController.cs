using System.Diagnostics;
using App.e_commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.e_commerce.Controllers
{
    public class HomeController : Controller
    {
        //Anasayfa
        public IActionResult Index()
        {
            return View();
        }
        //Hakkımızda
        public IActionResult AboutUs() { return View(); }
        //İletişim
        public IActionResult Contact() { return View(); }
        //Ürün Listeleme
        public IActionResult Listing() { return View(); }
        //Ürün Görüntüleme
        public IActionResult ProductDetail() { return View(); }


    }
}
