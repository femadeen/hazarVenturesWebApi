using HazarVenturesWebApi.Interfaces.Services;
using HazarVenturesWebApi.Models.RequestModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HazarVenturesWebApi.Authentication;
using HazarVenturesWebApi.Models.ResponseModels;
using HazarVenturesWebApi.Dtos;

namespace HazarVenturesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly  IJwtAuthentication _jwt;
        public UserController(IUserService userService, IJwtAuthentication jwt)
        {
            _userService = userService;
            _jwt = jwt;
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
            var token = _jwt.GenerateToken(loginStatus.Data);
            var response = new UserResponseModel
            {
                Data = loginStatus.Data,
                /*{   
                    Id = loginStatus.Data.Id,
                    FirstName = loginStatus.Data.FirstName,
                    LastName = loginStatus.Data.LastName,
                    Email = loginStatus.Data.Email,
                },*/
                Token = token
            };
            return Ok(response);
        }
    }
}
