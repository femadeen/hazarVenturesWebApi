using HazarVenturesWebApi.Interfaces.Services;
using HazarVenturesWebApi.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HazarVenturesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerController : ControllerBase
    {
        private readonly ILecturerService _lecturerService;
        public LecturerController(ILecturerService lecturerService)
        {
            _lecturerService = lecturerService;
        }

        [HttpPost("RegisterLecturer")]
        public async Task<IActionResult> RegisterLecturer(RegisterLecturerRequestModel model)
        {
            var lecturer = await _lecturerService.RegisterLecturer(model);
            if(lecturer.Status)
            {
                return Ok(lecturer);
            }
            else
            {
                return BadRequest(lecturer);
            }
        }

        [HttpGet("GetAllLecturers")]
        public async Task<IActionResult> GetAllLecuturers()
        {
            var lecturers = await _lecturerService.GetAllLecturer();
            return Ok(lecturers);
        }

        [HttpGet("GetLecturerDetails")]
        public async Task<IActionResult> GetLecturerDetails(int id)
        {
            var lecturer = await _lecturerService.GetLecturerById(id);
            if(lecturer.Status)
            {
                return Ok(lecturer);
            }
            else
            {
                return BadRequest(lecturer);
            }
        }
    }
}
