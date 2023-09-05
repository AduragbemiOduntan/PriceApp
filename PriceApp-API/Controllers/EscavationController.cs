using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceApp_Application.Services.Interfaces;

namespace PriceApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscavationController : ControllerBase
    {
        private readonly IEscavationService _ecavationService;

        public EscavationController(IEscavationService escavationService)
        {
            _ecavationService = escavationService;   
        }

        [HttpPost]
        public async Task<IActionResult> CreateEscavation(double girth, int uniqueProjectId)
        {
            var result = _ecavationService.CreateEscavationAsync(girth, uniqueProjectId);
            return Ok(result);
        }


    }
}
