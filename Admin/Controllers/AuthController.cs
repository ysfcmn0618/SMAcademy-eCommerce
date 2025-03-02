using App.Admin.Models.ViewModels;
using App.Data.MyDbContext;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    public class AuthController : Controller
    {
        private readonly ECommerceDbContext _dbContext;
        public AuthController(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
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

        [Route("/logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            // logout kodları...

            return RedirectToAction(nameof(Login));
        }
    }
}
