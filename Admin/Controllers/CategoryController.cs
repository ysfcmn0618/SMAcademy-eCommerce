using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class CategoryController : Controller
    {
        //Kategori Oluşturma
        public IActionResult Create()
        {
            return View();
        }
        //Kategori Düzenleme
        public IActionResult Edit()
        {
            return View();
        }
        //Ürünü silme
        public IActionResult Delete()
        {
            return View();
        }

    }
}
