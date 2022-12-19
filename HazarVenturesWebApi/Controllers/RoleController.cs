using HazarVenturesWebApi.Interfaces.Services;
using HazarVenturesWebApi.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HazarVenturesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleRequestModel model)
        {
            var role = await _roleService.CreateRole(model);
            if(role.Status)
            {
                return Ok(role);
            }
            else
            {
                return BadRequest(role);
            }
        }
    }
}
