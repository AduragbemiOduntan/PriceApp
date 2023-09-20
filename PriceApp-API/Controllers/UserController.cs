using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceApp_Application.Services.Interfaces;

namespace PriceApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsersAsync();
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("id")]
        public async Task<IActionResult> GetUserById([FromBody]string id)
        {
            var result = await _userService.GetUserByIdAsync(id);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("email")]
        public async Task<IActionResult> GetUserByEmail([FromBody] string email)
        {
             var result = await _userService.GetUserByEmailAsnc(email);
            return Ok(result);
        }

        /*[Authorize(Roles = "Admin")]*/
        [HttpDelete("email")]
        public async Task<IActionResult> DeleteUserByEmail([FromBody] string email)
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
