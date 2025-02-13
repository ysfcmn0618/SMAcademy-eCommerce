using Microsoft.AspNetCore.Mvc;

namespace App.eCommerce.Controllers
{
    public class CartController : Controller
    {
        [Route("new")]
        //Sepete Ürün Ekleme
        public IActionResult AddProduct()
        {
            return View();
        }
        [Route("edit/{id:int}")]
        //Sepetteki Ürünleri Düzenleme
        public IActionResult Edit([FromRoute] int id) { return View(); }
    }
}
