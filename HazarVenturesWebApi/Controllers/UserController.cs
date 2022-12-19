using HazarVenturesWebApi.Interfaces.Services;
using HazarVenturesWebApi.Models.RequestModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HazarVenturesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("UserInfo")]
        public async Task<IActionResult> UserInfo()
        {
            int id = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            var loginStatus = await _userService.Login(model);
            if (loginStatus.Status == false)
            {
                
                return BadRequest(loginStatus);
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, loginStatus.Data.Id.ToString()),
                new Claim(ClaimTypes.Email, loginStatus.Data.Email),
                new Claim(ClaimTypes.Role, loginStatus.Data.RoleName)
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authenticationProperties = new AuthenticationProperties();
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);
            return Ok(loginStatus);
        }
    }
}
