using App.Data.Entities;
using App.Data.Infrastructure.MyDbContext;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.Eticaret.Controllers
{
    public abstract class BaseController : Controller
    {
        protected T? GetService<T>() where T : class => HttpContext.RequestServices.GetService<T>();

        protected void SetSuccessMessage(string message) => ViewBag.SuccessMessage = message;

        protected void SetErrorMessage(string message) => ViewBag.ErrorMessage = message;

        protected string? GetCookie(string key) => Request.Cookies[key];

        protected void SetCookie(string key, string value) => Response.Cookies.Append(key, value);

        protected void RemoveCookie(string key) => Response.Cookies.Delete(key);

        protected async Task<UserEntity?> GetCurrentUserAsync()
        {
            //var userIdStr = GetCookie("userId");

            //if (!int.TryParse(userIdStr, out int userId))
            //{
            //    return null;
            //}

            //var dbContext = GetService<ECommerceDbContext>();

            //if (dbContext == null)
            //{
            //    return null;
            //}

            //return await dbContext.Users.FindAsync(userId);
            var userId = GetUserId();

            if (userId is null)
            {
                return null;
            }

            var clientFactory = GetService<IHttpClientFactory>();

            if (clientFactory == null)
            {
                return null;
            }

            var client = clientFactory.CreateClient("Api.Data");

            if (client == null)
            {
                return null;
            }

            var response = await client.GetAsync($"api/user/{userId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var user = await response.Content.ReadFromJsonAsync<UserEntity>();

            if (user == null)
            {
                return null;
            }

            return user;
        }

        protected bool IsUserLoggedIn() => /*GetCookie("userId") != null;*/User.Identity?.IsAuthenticated ?? false;

        protected int? GetUserId() => /*int.TryParse(GetCookie("userId"), out int userId) ? userId : null;*/int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId) ? userId : null;
    

        protected async Task<bool> IsUserAdminAsync()
        {
            var user = await GetCurrentUserAsync();

            return user?.RoleId == 1;
        }

        protected async Task<bool> IsUserSellerAsync()
        {
            var user = await GetCurrentUserAsync();

            return user?.RoleId == 2;
        }

        protected async Task<bool> IsUserBuyerAsync()
        {
            var user = await GetCurrentUserAsync();

            return user?.RoleId == 3;
        }
    }
}
