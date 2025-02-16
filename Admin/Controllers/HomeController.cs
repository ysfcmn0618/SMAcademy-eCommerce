using App.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.Admin.Controllers
{
    public class HomeController : Controller
    {        
        //Anasayfa
        public IActionResult Index()
        {
            return View();
        }       
    }
}
