using App.Admin.Models;
using App.Data.Infrastructure.MyDbContext;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ECommerceDbContext _dbContext;
        public HomeController(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Anasayfa
        public IActionResult Index()
        {
            return View();
        }       
    }
}
