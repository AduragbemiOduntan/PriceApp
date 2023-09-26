using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Entities;

namespace PriceApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService _authenticationService;

        public AuthenticationController(IAuthenticateService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Register a user. Takes in user DTO as parameter
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody]UserRequestDto userRequest)
        {
            var result = await _authenticationService.RegisterAsync(userRequest);
            return Ok(result);
        }

        /// <summary>
        /// User login. Takes login DTO as parameter
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginRequestDto loginRequest)
        {
            var result = await _authenticationService.LoginUser(loginRequest);
            return Ok(result);
        }

        /// <summary>
        /// Email confirmation token. Takes token and email as parameter
        /// </summary>
        [HttpGet("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromQuery]string token, string email)
        {
            var result = await _authenticationService.ConfirmEmail(token, email);
            return Ok(result);
        }

        /// <summary>
        /// Refresh token. Takes token DTO as parameter
        /// </summary>
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await
            _authenticationService.RefreshToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }

    }
}
