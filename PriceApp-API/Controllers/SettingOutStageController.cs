using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Requests;

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

/*        [HttpPost]
        public async Task<IActionResult> CreateSettingOut(SettingOutStageRequestDto settingOutStageRequest, double buildinSetbackPerimeter, int uniqueProjectId)
        {
            var result = _settingOutStageService.CreateSettingOutStageEstimate(settingOutStageRequest,buildinSetbackPerimeter, uniqueProjectId);
            return Ok(result);
        }*/
    }
}
