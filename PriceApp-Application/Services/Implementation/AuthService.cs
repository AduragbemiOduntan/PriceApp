using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Entities;
using PriceApp_Infrastructure.UOW;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PriceApp_Application.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private User _user;

        public AuthService(IUnitOfWork unitOfWork, ILogger<AuthService> logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration, IEmailService emailService)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _emailService = emailService;
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
                var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                var confirmationLink = await _emailService.GenerateEmailConfirmationLinkAsync(newUser.Email, emailConfirmationToken, "https"); 

                await _emailService.CreateEmail(newUser.Email, "Confirm Your Email", $"Please confirm your email by clicking this link: {confirmationLink}");

                await _userManager.AddToRoleAsync(newUser, "User");
                /*_logger.LogInformation($"User successfully created");*/
            }
            return StandardResponse<IdentityResult>.Success($"User successfully created{createdUser}", createdUser);
        }

        public async Task<string> ConfirmEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user == null)
            {
                return ("User does not exist");
            }
            var confirmedUser = await _userManager.ConfirmEmailAsync(user, token);
            if(!confirmedUser.Succeeded)
            {
                return ("Unsuccessful!");
            }
            return ("Successful! Email confirmed");
        }

        public async Task<bool> ValidateUser(LoginRequestDto loginRequest)
        {
            _user = await _userManager.FindByNameAsync(loginRequest.UserName);

            var userExist = (_user != null && await _userManager.CheckPasswordAsync(_user, loginRequest.Password));
            if (!userExist)
                _logger.LogWarning("Wrong user name or password.");
            return userExist;
        }

        public async Task<string> CreateToken()
        {
            var signingCredential = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredential, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
             (
                 issuer: jwtSettings["validIssuer"],
                 audience: jwtSettings["validAudience"],
                 claims: claims,
                 expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                 signingCredentials: signingCredentials
             );
            return tokenOptions;
        }

        public async Task<StandardResponse<string>> LoginUser(LoginRequestDto loginRequest)
        {
            if (!await ValidateUser(loginRequest))
                return StandardResponse<string>.Failed("Unauthorized");
            var token = await CreateToken();
            return StandardResponse<string>.Success("Authorized", token);
        }
    }
}
