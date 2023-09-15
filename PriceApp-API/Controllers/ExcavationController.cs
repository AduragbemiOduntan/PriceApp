using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceApp_Application.Services.Interfaces;

namespace PriceApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcavationController : ControllerBase
    {
        private readonly IExcavationService _excavationService;

        public ExcavationController(IExcavationService excavationService)
        {
            _excavationService = excavationService;   
        }

        [HttpPost]
        public async Task<IActionResult> CreateExcavation(double girth, int uniqueProjectId)
        {
            var result = _excavationService.CreateExcavationAsync(girth, uniqueProjectId);
            return Ok(result);
        }
    }
}
