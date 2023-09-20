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

       /* [Authorize]*/
        [HttpPost]
        public async Task<IActionResult> CreateSettingOut([FromBody]double buidingSetbackPerimeter, string stage, string state, string appellation)
        {
            var result = await _settingOutStageService.CreateSettingOutAsync(buidingSetbackPerimeter, stage, state, appellation);
            return Ok(result);
        }

       /* [Authorize]*/
        [HttpGet("uniqueId")]
        public async Task<IActionResult> GetSettingOutByAppellation([FromBody]string state, string appellation)
        {
            var result = await _settingOutStageService.GetSettingOutByAppellationAsync(state, appellation);
            return Ok(result);
        }

       /* [Authorize]*/
        [HttpGet]
        public async Task<IActionResult> GetAllSettingOut()
        {
            var result = await _settingOutStageService.GetAllSettingOutAsync();
            return Ok(result);
        }
    }
}
