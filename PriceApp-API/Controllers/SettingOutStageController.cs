using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PriceApp_Application.Services.Interfaces;

namespace PriceApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingOutStageController : ControllerBase
    {
        private readonly ISettingOutStageService _settingOutStageService;
        public SettingOutStageController(ISettingOutStageService settingOutStageService)
        {
            _settingOutStageService = settingOutStageService;
        }

        /// <summary>
        /// Create setting-out material cost estimate. Takes building setback peremeter, stage, state, appellation as parameter
        /// </summary>
        /*[Authorize]*/
        [HttpPost("createsettingout")]
        public async Task<IActionResult> CreateSettingOut(double buidingSetbackPerimeter, string stage, string state, string appellation)
        {
            var result = await _settingOutStageService.CreateSettingOutAsync(buidingSetbackPerimeter, stage, state, appellation);
            return Ok(result);
        }

        /// <summary>
        /// Get setting-out material cost estimate by ID. Takes state and appellation as parameter
        /// </summary>
        /*[Authorize]*/
        [HttpGet("appellation")]
        public async Task<IActionResult> GetSettingOutByAppellation(string state, string appellation)
        {
            var result = await _settingOutStageService.GetSettingOutByAppellationAsync(state, appellation);
            return Ok(result);
        }

        /// <summary>
        /// Get all setting-out material cost estimate. Takes no parameter
        /// </summary>
        /*[*//*Authorize]*/
        [HttpGet]
        public async Task<IActionResult> GetAllSettingOut()
        {
            var result = await _settingOutStageService.GetAllSettingOutAsync();
            return Ok(result);
        }
    }
}
