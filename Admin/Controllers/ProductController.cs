using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class ProductController : Controller
    {
        [Route("delete/{id:int}")]
        //Ürünü Silme
        public IActionResult Delete([FromRoute] int id)
        {
            return View();
        }
    }
}
