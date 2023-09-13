using Microsoft.AspNetCore.Mvc;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Responses.stages;
using PriceApp_Domain.Dtos.Responses;

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

        [HttpPost("foundationBaseCasting")]
        public async Task<IActionResult> CreateFoundationBaseCasting(double girth)
        {
            var result = await _materialEstimateService.CreateFoundationBaseCastingAsync(girth);
            return Ok(result);
        }

        [HttpPost("foundationColumnAndReinforcement")]
        public async Task<IActionResult> CreateFoundationColumnAndReinforcement(double girth)
        {
            var result = await _materialEstimateService.CreateFoundationColumnAndReinforcementAsync(girth);
            return Ok(result);
        }

        [HttpPost("foundationBlockwork")]
        public async Task<IActionResult> CreateFoundationBlockWorkA(double girth)
        {
            var result = await _materialEstimateService.CreateFoundationBlockWorkAsync(girth);
            return Ok(result);
        }

        [HttpPost("foundationBackfilling")]
        public async Task<IActionResult> CreateFoundationBackfilling(double buildingLength, double buildingBreath)
        {
            var result = await _materialEstimateService.CreateFoundationBackfillingAsync(buildingLength, buildingBreath);
            return Ok(result);
        }

        [HttpPost("germanFloor")]
        public async Task<IActionResult> CreateGermanFloor(double buildingLength, double buildingBreath)
        {
            var result = await _materialEstimateService.CreateGermanFloorAsync(buildingLength, buildingBreath);
            return Ok(result);
        }


    }

}
