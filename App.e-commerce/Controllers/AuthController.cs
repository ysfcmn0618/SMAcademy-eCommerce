using Microsoft.AspNetCore.Mvc;
using App.eCommerce.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using App.Data.MyDbContext;

namespace App.eCommerce.Controllers
{
    public class AuthController : Controller
    {
        private readonly ECommerceDbContext _dbContext;

        public AuthController(ECommerceDbContext _db)
        {
            _dbContext = _db;
        }
        [Route("/register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Route("/login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("/login")]
        [HttpPost]
        public IActionResult Login([FromForm] LoginViewModel loginModel)
        {
            return View();
        }

        [Route("/forgot-password")]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [Route("/forgot-password")]
        [HttpPost]
        public IActionResult ForgotPassword([FromForm] object forgotPasswordMailModel)
        {
            return View();
        }

        [Route("/renew-password/{verificationCode}")]
        [HttpGet]
        public IActionResult RenewPassword([FromRoute] string verificationCode)
        {
            return View();
        }

        [Route("/renew-password")]
        [HttpPost]
        public IActionResult RenewPassword([FromForm] object changePasswordModel)
        {
            return View();
        }

        [Route("/logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            // logout kodları...

            return RedirectToAction(nameof(Login));
        }
    }
}
