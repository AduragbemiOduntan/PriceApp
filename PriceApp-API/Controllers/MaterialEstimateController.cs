using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PriceApp_Application.Services.Implementation;
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

        /// <summary>
        /// Get all material estimate. Takes no parameter
        /// </summary>
        /*    [Authorize]*/
        [HttpGet]
        public async Task<IActionResult> GetAllMaterialEstimate()
        {
            var result = await _materialEstimateService.GetAllMaterialEstimateAsync();
            return Ok(result);
        }

        /*     [Authorize]*/
        /*        [HttpGet("appellationAndStage")]
                public async Task<IActionResult> GetMaterialEstimateByAppelationAndStage(string appellation, string stage)
                {
                    var result = await _materialEstimateService.GetMaterialEstimateByAppelationAndStageAsync(appellation, stage);
                    return Ok(result);
                }*/
    }
}
