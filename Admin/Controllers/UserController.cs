using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class UserController : Controller
    {
        //Kullanıcı Listeleme
        public IActionResult List()
        {
            return View();
        }
        //Satıcı Olma Onayı
        public IActionResult Approve()
        {
            return View();
        }
    }
}
