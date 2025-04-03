using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Data.MyDbContext;
using System.Threading.Tasks;
using App.eCommerce.Models.ViewModels.AuthViewModels;
using App.DbServices.MyEntityInterfacess;
using App.Data.Entities;
using AutoMapper;
using App.DbServices;
using App.Eticaret.Controllers;

namespace App.eCommerce.Controllers
{
    public class AuthController(IBaseDbService<UserEntity> _dbContext, IMapper _mapper) : BaseController
    {
        //    private readonly IBaseDbService<UserEntity> _dbContext;
        //    private readonly IMapper _mapper;

        //public AuthController():base()
        //{
        //    _dbContext = _db;
        //    _mapper = mapper;
        //}
        [Route("register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterUserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            //Mapleme işlemleri lazım
            var newUser = _mapper.Map<UserEntity>(user);
            await _dbContext.Add(newUser);

            ViewBag.SuccessMessage = "Kayıt işlemi başarılı. Giriş yapabilirsiniz.";
            ModelState.Clear();

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
        public async Task<IActionResult> Login([FromForm] LoginViewModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }
            var user = await _dbContext.FirstOrDefaultAsync(u => u.Email == loginModel.Email && u.Password == loginModel.Password);
            if (user is null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı.");
                return View(loginModel);
            }
            await LogInAsync(user);
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
        public async Task<IActionResult> ForgotPassword([FromForm] ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _dbContext.FirstOrDefaultAsync(u => u.Email == model.Email);
            if (user is null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı.");
                return View(model);
            }
            // Şifre sıfırlama kodu oluşturulacak ve kullanıcıya mail gönderilecek...
            await SendResetPasswordEmailAsync(user);
            ViewBag.SuccessMessage = "Şifre sıfırlama maili gönderildi. Lütfen e-posta adresinizi kontrol edin.";
            ModelState.Clear();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [Route("renew-password/{verificationCode}")]
        [HttpGet]
        public IActionResult RenewPassword([FromRoute] string verificationCode)
        {
            return View();
        }

        [Route("renew-password")]
        [HttpPost]
        public IActionResult RenewPassword([FromForm] RenevPasswordViewModel changePasswordModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [Route("logout")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            // logout kodları...
            await LogoutUser();
            return RedirectToAction(nameof(Login));
        }
        private async Task LogInAsync(UserEntity user)
        {
            if (user == null)
            {
                return;
            }
            
            SetCookie("userId", user.Id.ToString());
            SetCookie("mail", user.Email);
            SetCookie("name", user.FirstName);
            SetCookie("surname", user.LastName);
            SetCookie("role", user.RoleId.ToString());

            await Task.CompletedTask;
        }
        private async Task LogoutUser()
        {
            // TODO: Authorization implemente edildikten sonra bu metot tamamlanacak...

            RemoveCookie("userId");
            RemoveCookie("mail");
            RemoveCookie("name");
            RemoveCookie("surname");
            RemoveCookie("role");
        }
        private async Task SendResetPasswordEmailAsync(UserEntity user)
        {
            // Şifre sıfırlama maili gönderme kodları...
            // TODO: Authorization implemente edildikten sonra bu metot tamamlanacak...
            if (user == null)
            {
                return;
            }

            await Task.CompletedTask;
        }
    }
}
