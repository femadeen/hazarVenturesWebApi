using HazarVenturesWebApi.Interfaces.Services;
using HazarVenturesWebApi.Models.RequestModels;
using HazarVenturesWebApi.Models.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HazarVenturesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("RegisterStudent")]
        public async Task<IActionResult> RegisterStudent(RegisterStudentRequstModel request)
        {
            var student = await _studentService.AddStudent(request);
            if(student.Status)
            {
                return Ok(student);
            }
            else
            {
                return BadRequest(student);
            }
        }

        [HttpGet("GetAllStudent")]  
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("GetStudentDetails")]
        public async Task<IActionResult> GetStudentDetails(int id)
        {
            var student = await _studentService.GetStudentById(id);
            if(student.Status)
            {
                return Ok(student);
            }
            else
            {
                return BadRequest(student);
            }
           
        }

        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(int id, UpdateStudentRequestModel request)
        {
           var student =  await _studentService.UpdateStudent(id, request);
            return Ok(student);
        }

        

        
        [HttpDelete("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentService.DeleteStudent(id);
            return Ok(student);
        }

    }
}
