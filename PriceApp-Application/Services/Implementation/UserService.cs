using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<StandardResponse<IEnumerable<UserResponseDto>>> GetAllUsersAsync(bool trackChanges)
        {

            _logger.LogInformation($"Attempting to get users {DateTime.Now}");
            var users = await _unitOfWork.User.FindAll(trackChanges).ToListAsync();
           var returnUsers = _mapper.Map<IEnumerable<UserResponseDto>>(users);

            /*
                        var usersReturned = _mapper.Map<UserResponseDto>(IEnumerable<User>);

                        if (users == null)
                        {
                            _logger.LogError("No user available");
                        }*/

            return StandardResponse<IEnumerable<UserResponseDto>>.Success($"Users successfully retrieved", returnUsers);
        }

    }
}
