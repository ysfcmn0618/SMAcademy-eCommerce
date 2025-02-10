using Microsoft.AspNetCore.Mvc;

namespace App.e_commerce.Controllers
{
    public class ProfileController : Controller
    {
        [Route("detail/{id:int}/{name}-{surname}")]
        //Kullanıcı Bilgileri Görüntüleme
        public IActionResult Details()
        {
            return View();
        }
        [Route("edit/{id:int}/{name}-{surname}")]
        //Kullanıcı Bilgileri Güncelleme
        public IActionResult Edit() { return View(); }
        [Route("my-order-list")]
        //Siparişlerim
        public IActionResult MyOrders() { return View(); }
        [Route("my-product-list")]
        //Satıcı Kendi Ürünlerini Listeleme
        public IActionResult MyProducts() { return View(); }

    }
}
