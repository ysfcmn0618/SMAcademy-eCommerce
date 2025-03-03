using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Data.MyDbContext;
using System.Threading.Tasks;
using App.eCommerce.Models.ViewModels.AuthViewModels;

namespace App.eCommerce.Controllers
{
    public class AuthController : Controller
    {
        private readonly ECommerceDbContext _dbContext;

        public AuthController(ECommerceDbContext _db)
        {
            _dbContext = _db;
        }
        [Route("register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterUserModel user)
        {
            if (!ModelState.IsValid)
            {                
                return View();
            }
            //Mapleme işlemleri lazım 
            // await _dbContext.Users.AddAsync(user);
            return RedirectToAction(nameof(Login), "Auth");
        }


        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //[Route("login")]
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromForm] LoginViewModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [Route("forgot-password")]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [Route("forgot-password")]
        [HttpPost]
        public IActionResult ForgotPassword([FromForm] ForgotPasswordViewModel forgotPasswordMailModel)
        {
            return View();
        }

        [Route("renew-password/{verificationCode}")]
        [HttpGet]
        public IActionResult RenewPassword([FromRoute] string verificationCode)
        {
            return View();
        }

        [Route("renew-password")]
        [HttpPost]
        public IActionResult RenewPassword([FromForm] object changePasswordModel)
        {
            return View();
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            // logout kodları...

            return RedirectToAction(nameof(Login));
        }
    }
}
