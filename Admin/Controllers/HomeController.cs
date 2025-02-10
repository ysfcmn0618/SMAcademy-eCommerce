using Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Admin.Controllers
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
