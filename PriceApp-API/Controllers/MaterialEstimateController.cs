using Microsoft.AspNetCore.Mvc;
using PriceApp_Application.Services.Interfaces;

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
        public async Task<IActionResult> CreatePegME(double buidingSetbackPermeter, string stage, int uniqueProjectId)
        {
            var result = await _materialEstimateService.CreatePegMEService( buidingSetbackPermeter, stage, uniqueProjectId);
            return Ok(result);
        }

        [HttpGet("UniqueId")]
        public async Task<IActionResult> GetMEByUPIdAndStage(int uniqueProjectId, string stage)
        {
            var result = await _materialEstimateService.GetMEByUniqueProjectIdAndStageAsync(uniqueProjectId, stage);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMaterialEstimate()
        {
            var result = await _materialEstimateService.GetAllMaterialEstimateAsync();
            return Ok(result);
        }

        [HttpPost("FoundationBaseCasting")]
        public async Task<IActionResult> CreateFoundationBaseCasting(double girth)
        {
            var result = await _materialEstimateService.CreateFoundationBaseCastingAsync(girth);
            return Ok(result);
        }
    }
}
