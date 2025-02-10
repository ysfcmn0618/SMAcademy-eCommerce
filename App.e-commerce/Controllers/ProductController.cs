using Microsoft.AspNetCore.Mvc;

namespace App.e_commerce.Controllers
{
    public class ProductController : Controller
    {
        //Ürün Oluşturma
        public IActionResult Create()
        {
            return View();
        }
        //Ürün Düzenleme
        public IActionResult Edit() { return View(); }
        //Ürün Silme
        public IActionResult Delete() { return View(); }
        //Ürüne Yorum ve Yıldız Yapma
        public IActionResult Comment() { return View(); }

    }
}
