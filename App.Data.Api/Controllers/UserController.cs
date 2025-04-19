using App.Data.Api.Models;
using App.Data.Entities;
using App.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Data.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IGenericRepository<UserEntity> dataRepository) : ControllerBase
    {
        [HttpPost("login", Name = "GetUser")]
        public async Task<IActionResult> Get([FromBody] LoginDto login)
        {

            if (string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
            {
                return BadRequest();
            }

            var user = await dataRepository.GetAllAsync()
                .Include(u => u.Role)
                .SingleOrDefaultAsync(u => u.Email == login.Email && u.Password == login.Password);

            if (user is null)
            {
                return NotFound();
            }

            user.Password = string.Empty;
            user.ResetPasswordToken = string.Empty;

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await dataRepository.GetAllAsync()
                .Include(u => u.Role)
                .ToListAsync();

            foreach (var user in users)
            {
                user.Password = string.Empty;
                user.ResetPasswordToken = string.Empty;
            }

            return Ok(users);
        }


        [HttpGet("reset-password-token/{token}")]
        public async Task<IActionResult> GetUserByResetToken(string token)
        {
            var user = await dataRepository.GetAllAsync()
                .FirstOrDefaultAsync(u => u.ResetPasswordToken == token);

            if (user is null)
            {
                return NotFound();
            }

            user.Password = string.Empty;
            user.ResetPasswordToken = string.Empty;

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await dataRepository.GetById(id);

            if (user is null)
            {
                return NotFound();
            }

            user.Password = string.Empty;
            user.ResetPasswordToken = string.Empty;

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserEntity user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await dataRepository.Update(user);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserEntity user)
        {
            user = await dataRepository.Add(user);
            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }


    }
}
