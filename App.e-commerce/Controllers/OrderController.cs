using Microsoft.AspNetCore.Mvc;

namespace App.eCommerce.Controllers
{
    public class OrderController : Controller
    {
        [Route("/order")]
        [HttpPost]
        //Sipariş Oluşturma
        public IActionResult Create()
        {
            var orderId = 1;
            return RedirectToAction(nameof(Details), new { orderId });
        }
        [Route("/order/{id:int}/details")]
        [HttpGet]
        //Sipariş Detayları
        public IActionResult Details([FromRoute]int id) { return View(); }
    }
}
