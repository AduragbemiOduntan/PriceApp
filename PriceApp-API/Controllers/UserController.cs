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

        [HttpGet]
        [Route("get-allUser")]
        public async Task<IActionResult> GetAllUsers(bool trackChanges)
        {
            var result = await _userService.GetAllUsersAsync(trackChanges);
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetUserById(string id, bool trackChanges)
        {
            var result = await _userService.GetUserByIdAsync(id, trackChanges);
            return Ok(result);
        }

        [HttpGet("email")]
        public async Task<IActionResult> GetUserByEmail(string email, bool trackChanges)
        {
             var result = await _userService.GetUserByEmailAsnc(email, trackChanges);
            return Ok(result);
        }

/*        [HttpDelete]
        public async Task<IActionResult> DeleteUserById(string id, bool trackChanges)
        {
            var result = await _userService.DeleteUserByIdAsync(id, trackChanges);
            return Ok(result);
        }

        [HttpDelete("email")]
        public async Task<IActionResult> DeleteUserByEmail(string email, bool trackChanges)
        {
            var result = await _userService.DeleteUserByEmailAsync(email, trackChanges);
            return Ok(result);
        }*/
    }
}
