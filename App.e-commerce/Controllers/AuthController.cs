using Microsoft.AspNetCore.Mvc;

namespace App.e_commerce.Controllers
{
    public class AuthController : Controller
    {
        //Kullanıcı Girişi
        public IActionResult Login()
        {
            return View();
        }
        //Kullanıcı KAydı
        public IActionResult Register() { return View(); }
        //Şifremi unuttum
        public IActionResult ForgotPassword() { return View(); }
        //Kullanıcı Çıkışı
        public IActionResult LogOut() { return View(); }

    }
}
