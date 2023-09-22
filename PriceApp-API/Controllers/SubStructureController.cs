using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PriceApp_Application.Services.Interfaces;

namespace PriceApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubStructureController : ControllerBase
    {
        private readonly ISubStructureEstimateService _subStructureEstimateService;
        public SubStructureController( ISubStructureEstimateService subStructureEstimateService)
        {
            _subStructureEstimateService = subStructureEstimateService;
        }

        /*[Authorize]*/
        [HttpPost("foundationBaseCasting")]
        public async Task<IActionResult> CreateFoundationBaseCasting(double girth, string appellation)
        {
            var result = await _subStructureEstimateService.CreateFoundationBaseCastingAsync(girth, appellation);
            return Ok(result);
        }

     /*   [Authorize]*/
        [HttpPost("foundationColumnAndReinforcement")]
        public async Task<IActionResult> CreateFoundationColumnAndReinforcement( double girth, string appellation)
        {
            var result = await _subStructureEstimateService.CreateFoundationColumnAndReinforcementAsync(girth, appellation);
            return Ok(result);
        }

      /*  [Authorize]*/
        [HttpPost("foundationBlockwork")]
        public async Task<IActionResult> CreateFoundationBlockWorkA(double girth, string appellation)
        {
            var result = await _subStructureEstimateService.CreateFoundationBlockWorkAsync(girth, appellation);
            return Ok(result);
        }

     /*   [Authorize]*/
        [HttpPost("foundationBackfilling")]
        public async Task<IActionResult> CreateFoundationBackfilling(double buildingLength, double buildingBreath, string appellation)
        {
            var result = await _subStructureEstimateService.CreateFoundationBackfillingAsync(buildingLength, buildingBreath, appellation);
            return Ok(result);
        }

      /*  [Authorize]*/
        [HttpPost("germanFloor")]
        public async Task<IActionResult> CreateGermanFloor(double buildingLength, double buildingBreath, string appellation)
        {
            var result = await _subStructureEstimateService.CreateGermanFloorAsync(buildingLength, buildingBreath, appellation);
            return Ok(result);
        }
    }
}
