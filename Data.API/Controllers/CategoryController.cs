using App.Data.Entities;
using App.Data.Repository;
using App.DbServices.MyEntityInterfacess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Data.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IGenericRepository<CategoryEntity> repo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await repo.GetAll();
            return Ok(categories);
        }


    }
}
