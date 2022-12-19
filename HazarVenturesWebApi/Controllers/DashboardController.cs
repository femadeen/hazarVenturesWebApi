using HazarVenturesWebApi.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HazarVenturesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IGeneralService _generalService;
        public DashboardController(IGeneralService generalService)
        {
            _generalService = generalService;
        }

        [HttpGet("DashboardCount")]
        public  async Task<IActionResult> DashboardCount()
        {
            var generalCount = await _generalService.DashBoard();
            return Ok(generalCount);
        }
    }
}
