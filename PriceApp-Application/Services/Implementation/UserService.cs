using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Entities;
using PriceApp_Infrastructure.UOW;

namespace PriceApp_Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;


        public UserService(IUnitOfWork unitOfWork, ILogger<UserService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<StandardResponse<IEnumerable<UserResponseDto>>> GetAllUsersAsync()
        {
            _logger.LogInformation($"Attempting to get users {DateTime.Now}");
            var users = await _unitOfWork.User.FindAll(false).OrderBy(x => x.Id).ToListAsync();

            if (users == null)
            {
                _logger.LogError("No user exist");
                return StandardResponse<IEnumerable<UserResponseDto>>.Failed($"Users do not exist");
            }

            var usersReturned = _mapper.Map<IEnumerable<UserResponseDto>>(users);
            return StandardResponse<IEnumerable<UserResponseDto>>.Success($"Users successfully retrieved", usersReturned);
        }

        public async Task<StandardResponse<UserResponseDto>> GetUserByIdAsync(string id)
        {
            if (id == null)
            {
                _logger.LogError("Id field cannot be empty");
                return StandardResponse<UserResponseDto>.Failed("Id field cannot be empty");
            }

            _logger.LogInformation($"Attempting to get user with id {id} {DateTime.Now}");
            var user = await _unitOfWork.User.FindUserById(id);

            if (user == null)
            {
                _logger.LogError($"User does not exit");
                return StandardResponse<UserResponseDto>.Failed($"User does not exist");
            }
            var userReturned = _mapper.Map<UserResponseDto>(user);
            return StandardResponse<UserResponseDto>.Success($"User successfully retrieved", userReturned);
        }

        public async Task<StandardResponse<UserResponseDto>> GetUserByEmailAsnc(string email)
        {
            if (email == null)
            {
                _logger.LogError("Email field cannot be empty");
                return StandardResponse<UserResponseDto>.Failed("Email field cannot be empty");
            }

            _logger.LogInformation($"Attempting to get user with email {email} {DateTime.Now}");
            var user = await _unitOfWork.User.FindUserByEmail(email);

            if (user == null)
            {
                _logger.LogError($"User does not exit");
                return StandardResponse<UserResponseDto>.Failed($"User does not exist");
            }

            var userReturned = _mapper.Map<UserResponseDto>(user);
            return StandardResponse<UserResponseDto>.Success($"User successfully retrieved", userReturned);
        }

        public async Task<StandardResponse<User>> DeleteUserByIdAsync(string id)
        {
            _logger.LogInformation($"Attempting to delete user with id {id}");
            var user = await _unitOfWork.User.FindUserById(id);

            if (user == null)
            {
                _logger.LogError($"User does not exit");
                return StandardResponse<User>.Failed($"The user with id {id} does not exist");
            }
            _unitOfWork.User.Delete(user);
            await _unitOfWork.SaveAsync();
            return StandardResponse<User>.Success($"Delete successful", user);
        }

        public async Task<StandardResponse<User>> DeleteUserByEmailAsync(string email)
        {
            if (email == null)
            {
                _logger.LogError($"Email field cannot be empty");
                return StandardResponse<User>.Failed("Email field cannot be empty");
            }
            var user = await _unitOfWork.User.FindUserByEmail(email);

            if (user == null)
            {
                _logger.LogError($"User does not exit");
                return StandardResponse<User>.Failed($"The user with email {email} does not exist");
            }
            _unitOfWork.User.Delete(user);
            await _unitOfWork.SaveAsync();
            return StandardResponse<User>.Success($"Delete successful", user);
        }
    }
}
