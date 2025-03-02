using App.Data.MyDbContext;
using Microsoft.AspNetCore.Mvc;

namespace App.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly ECommerceDbContext _dbContext;
        public UserController(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Route("/users")]
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [Route("/users/{userId:int}/approve")]
        [HttpGet]
        public IActionResult Approve([FromRoute] int userId)
        {
            return View();
        }
    }
}
