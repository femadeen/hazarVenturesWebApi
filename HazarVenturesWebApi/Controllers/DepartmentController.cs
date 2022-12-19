using HazarVenturesWebApi.Interfaces.Services;
using HazarVenturesWebApi.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HazarVenturesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("GetAllDepartments")]
        public async Task<IActionResult> GetAllDepartments()
        {
            var department = await _departmentService.GetAllDepartments();
            return Ok(department);
        }

        [HttpPost("CreateDepartment")]
        public async Task<IActionResult> CreateDepartment(RegisterDepartmentRequestModel model)
        {
            var department = await _departmentService.AddDepartment(model);
            if(department.Status)
            {
                return Ok(department);
            }
            else
            {
                return BadRequest(department);
            }
        }

    }
}
