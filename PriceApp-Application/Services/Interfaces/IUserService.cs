using Microsoft.AspNetCore.Identity;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Entities;

namespace PriceApp_Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<StandardResponse<IEnumerable<UserResponseDto>>> GetAllUsersAsync(bool trackChanges);
        Task<StandardResponse<UserResponseDto>> GetUserByIdAsync(string id, bool trackChanges);
        Task<StandardResponse<UserResponseDto>> GetUserByEmailAsnc(string email, bool trackChanges);
        Task<StandardResponse<User>> DeleteUserByIdAsync(string id, bool trackChanges);
        Task<StandardResponse<User>> DeleteUserByEmailAsync(string email, bool trackChanges);
    }
}
