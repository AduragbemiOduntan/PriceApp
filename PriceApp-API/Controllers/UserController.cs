using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Responses;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace PriceApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get a list of all registered users. Takes no parameter
        /// </summary>
        /// <response code="200">Returns a list with the available sample responses.</response>
        [HttpGet("allusers")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<IEnumerable<UserResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        /*[Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsersAsync();
            return Ok(result);
        }

        /// <summary>
        /// Get a single user by ID. Takes user database ID as parameter
        /// </summary>
        /* [Authorize(Roles = "Admin")]*/
        [HttpGet("userid")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<IEnumerable<UserResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> GetUserById([FromBody]string id)
        {
            var result = await _userService.GetUserByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Get a single user by email. Takes user email as parameter
        /// </summary>
        /* [Authorize]*/
        [HttpGet("email")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
             var result = await _userService.GetUserByEmailAsnc(email);
            return Ok(result);
        }

        /// <summary>
        /// Delete a user by email. Takes user email as parameter
        /// </summary>
        /*[Authorize(Roles = "Admin")]*/
        [HttpDelete("useremail")]
        public async Task<IActionResult> DeleteUserByEmail(string email)
        {
            var result = await _userService.DeleteUserByEmailAsync(email);
            return Ok(result);
        }

        /*      [HttpDelete]
                public async Task<IActionResult> DeleteUserById([FromBody]string id)
                {
                    var result = await _userService.DeleteUserByIdAsync(id);
                    return Ok(result);
                }*/
    }
}
