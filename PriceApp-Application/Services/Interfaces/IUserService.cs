using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Entities;

namespace PriceApp_Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<StandardResponse<IEnumerable<UserResponseDto>>> GetAllUsersAsync();
        Task<StandardResponse<UserResponseDto>> GetUserByIdAsync(string id);
        Task<StandardResponse<UserResponseDto>> GetUserByEmailAsnc(string email);
        Task<StandardResponse<User>> DeleteUserByIdAsync(string id);
        Task<StandardResponse<User>> DeleteUserByEmailAsync(string email);
    }
}
