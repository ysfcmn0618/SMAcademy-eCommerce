using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class CategoryController : Controller
    {
        [Route("new")]
        //Kategori Oluşturma
        public IActionResult Create()
        {
            return View();
        }
        [Route("{id:int}/edit")]
        //Kategori Düzenleme
        public IActionResult Edit([FromRoute]int id)
        {
            return View();
        }
        [Route("{id:int}")]
        //Ürünü silme
        public IActionResult Delete([FromRoute] int id)
        {
            return View();
        }

    }
}
