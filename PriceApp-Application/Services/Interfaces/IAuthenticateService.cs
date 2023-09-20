using Microsoft.AspNetCore.Identity;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;

namespace PriceApp_Application.Services.Interfaces
{
    public interface IAuthenticateService
    {
        Task<StandardResponse<IdentityResult>> RegisterAsync(UserRequestDto userRequest);
        Task<bool> ValidateUser(LoginRequestDto loginRequest);
        /*Task<string> CreateToken();*/
        Task<StandardResponse<string>> LoginUser(LoginRequestDto loginRequest);
        Task<string> ConfirmEmail(string token, string email);
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        
    }
}
