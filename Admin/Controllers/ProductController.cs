using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class ProductController : Controller
    {
        //Ürünü Silme
        public IActionResult Delete()
        {
            return View();
        }
    }
}
