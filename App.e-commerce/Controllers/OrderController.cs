using Microsoft.AspNetCore.Mvc;

namespace App.eCommerce.Controllers
{
    public class OrderController : Controller
    {
        [Route("new")]
        //Sipariş Oluşturma
        public IActionResult Create()
        {
            return View();
        }
        [Route("/order/{id:int}/details")]
        //Sipariş Detayları
        public IActionResult Details([FromRoute]int id) { return View(); }
    }
}
