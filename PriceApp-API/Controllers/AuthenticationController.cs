using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Entities;

namespace PriceApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authenticationService;

        public AuthenticationController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("register-user")]
        public async Task<IActionResult> RegisterUser([FromBody]UserRequestDto userRequest)
        {
            var result = await _authenticationService.RegisterAsync(userRequest);

            return Ok(result);
        }

        [HttpPost]
        [Route("login-user")]
        public async Task<IActionResult> LoginUser([FromBody] LoginRequestDto loginRequest)
        {
            var result = await _authenticationService.LoginUser(loginRequest);
            return Ok(result);
        }

        [HttpGet]
        [Route("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery]string token, string email)
        {
            var result = await _authenticationService.ConfirmEmail(token, email);
            return Ok(result);
        }
    }
}
