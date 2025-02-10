using Microsoft.AspNetCore.Mvc;

namespace App.e_commerce.Controllers
{
    public class OrderController : Controller
    {
        //Sipariş Oluşturma
        public IActionResult Create()
        {
            return View();
        }
        //Sipariş Detayları
        public IActionResult Details() { return View(); }
    }
}
