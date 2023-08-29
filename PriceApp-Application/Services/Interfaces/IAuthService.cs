using Microsoft.AspNetCore.Identity;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Application.Services.Interfaces
{
    public interface IAuthService
    {
        /*    Task<IdentityResult> RegisterAsync(UserRequestDto userRequest);*/
        Task<StandardResponse<IdentityResult>> RegisterAsync(UserRequestDto userRequest);
        Task<IdentityResult> LoginAsync(UserLoginRequestDto userLoginRequest);
    }
}
