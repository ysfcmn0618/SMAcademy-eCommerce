using Microsoft.AspNetCore.Mvc;

namespace App.e_commerce.Controllers
{
    public class CartController : Controller
    {
        //Sepete Ürün Ekleme
        public IActionResult AddProduct()
        {
            return View();
        }
        //Sepetteki Ürünleri Düzenleme
        public IActionResult Edit() { return View(); }
    }
}
