using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Entities;
using PriceApp_Infrastructure.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Application.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(IUnitOfWork unitOfWork, ILogger<AuthService> logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<StandardResponse<IdentityResult>> RegisterAsync(UserRequestDto userRequest)
        {
            if (userRequest == null)
            {
                _logger.LogError("User details cannot be empty");
                return null;
            }
            _logger.LogInformation("Attempting to create user");

            var newUser = _mapper.Map<User>(userRequest);
            var createdUser = await _userManager.CreateAsync(newUser, userRequest.Password);
            if (createdUser.Succeeded)
            {
                await _userManager.AddToRolesAsync(newUser, userRequest.Roles);
                /*_logger.LogInformation($"User successfully created");*/
            }
            return  StandardResponse<IdentityResult>.Success($"User successfully created{createdUser}", createdUser);
        }

        public async Task<IdentityResult> LoginAsync(UserLoginRequestDto userLoginRequest)
        {
            /*if (_userManager == null)
            {
                _logger.LogError("Login  details cannot be empty");
                return StandardResponse<IdentityResult>.Failed("Login attempt failed");
            }
            _logger.LogInformation("Attempting to login");
*/
            throw new NotImplementedException();

        }

    }
}
