using App.Data.Entities;
using App.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Data.Api.Controllers
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await repo.GetById(id);
            if (category is null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryEntity category)
        {
            await repo.Add(category);
            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryEntity category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            await repo.Update(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await repo.GetById(id);
            // Silinecek kategori var mı kontrol et
            if (category is null)
            {
                return NotFound();
            }

            await repo.Delete(id);
            return NoContent();
        }
    }
}
