using Microsoft.AspNetCore.Identity;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Entities;

namespace PriceApp_Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<StandardResponse<IEnumerable<UserResponseDto>>> GetAllUsersAsync(bool trackChanges);
    }
}
