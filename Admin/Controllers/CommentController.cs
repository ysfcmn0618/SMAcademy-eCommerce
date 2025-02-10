using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class CommentController : Controller
    {
        //Yorum Listeleme
        public IActionResult List()
        {
            return View();
        }
        //Yorum Onaylama
        public IActionResult Approve ()
        {
            return View();
        }
    }
}
