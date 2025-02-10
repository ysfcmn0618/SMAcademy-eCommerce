using Microsoft.AspNetCore.Mvc;

namespace App.e_commerce.Controllers
{
    public class ProfileController : Controller
    {
        //Kullanıcı Bilgileri Görüntüleme
        public IActionResult Details()
        {
            return View();
        }
        //Kullanıcı Bilgileri Güncelleme
        public IActionResult Edit() { return View(); }
        //Siparişlerim
        public IActionResult MyOrders() { return View(); }
        //Satıcı Kendi Ürünlerini Listeleme
        public IActionResult MyProducts() { return View(); }

    }
}
