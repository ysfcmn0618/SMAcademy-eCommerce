using Microsoft.AspNetCore.Mvc;

namespace App.e_commerce.Controllers
{
    public class ProductController : Controller
    {
        [Route("new")]
        //Ürün Oluşturma
        public IActionResult Create()
        {
            return View();
        }
        [Route("edit/{id:int}")]
        //Ürün Düzenleme
        public IActionResult Edit([FromRoute] int id) { return View(); }
        [Route("delete/{id:int}")]
        //Ürün Silme
        public IActionResult Delete([FromRoute] int id) { return View(); }
        [Route("comment/{id:int}")]
        //Ürüne Yorum ve Yıldız Yapma
        public IActionResult Comment([FromRoute]int id ) { return View(); }

    }
}
