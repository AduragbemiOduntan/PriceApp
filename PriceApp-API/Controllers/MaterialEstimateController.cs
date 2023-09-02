using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Requests;

namespace PriceApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialEstimateController : ControllerBase
    {
        private readonly IMaterialEstimateService _materialEstimateService;

        public MaterialEstimateController( IMaterialEstimateService materialEstimateService)
        {
            _materialEstimateService = materialEstimateService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePegME(double buidingSetbackPermeter, string stage)
        {
            var result = await _materialEstimateService.CreatePegMEService( buidingSetbackPermeter, stage);
            return Ok(result);
        }
    }
}
