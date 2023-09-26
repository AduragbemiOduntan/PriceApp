using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PriceApp_Application.Services.Interfaces;
using PriceApp_Domain.Dtos.Requests;
using PriceApp_Domain.Dtos.Responses;
using PriceApp_Domain.Entities;
using PriceApp_Domain.Exceptions;
using PriceApp_Infrastructure.UOW;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PriceApp_Application.Services.Implementation
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly ILogger<AuthenticateService> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private User _user;

        public AuthenticateService(IUnitOfWork unitOfWork, ILogger<AuthenticateService> logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration, IEmailService emailService)
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
            User newUser = _mapper.Map<User>(userRequest);
            newUser.UserName = userRequest.Email;

            var createdUser = await _userManager.CreateAsync(newUser, userRequest.Password);
            if (!createdUser.Succeeded)
            {
                return StandardResponse<IdentityResult>.Failed($"User creation failed");
            }
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
            if (user == null)
            {
                return ("User does not exist");
            }
            var confirmedUser = await _userManager.ConfirmEmailAsync(user, token);
            if (!confirmedUser.Succeeded)
            {
                return ("Unsuccessful!");
            }
            return ("Successful! Email confirmed");
        }

        public async Task<bool> ValidateUser(LoginRequestDto loginRequest)
        {
            _user = await _userManager.FindByNameAsync(loginRequest.Email);

            var userExist = (_user != null && await _userManager.CheckPasswordAsync(_user, loginRequest.Password));
            if (!userExist)
                _logger.LogWarning("Wrong email or password.");
            return userExist;
        }

        public async Task<TokenDto> CreateToken(bool populateExp)
        {
            var signingCredential = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredential, claims);

            var refreshToken = GenerateRefreshToken();
            _user.RefreshToken = refreshToken;
            if (populateExp)
                _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            await _userManager.UpdateAsync(_user);
            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new TokenDto(accessToken, refreshToken);
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
                new Claim(ClaimTypes.Name, _user.Email)
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
            if (string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
                return StandardResponse<string>.Failed("Field can not be empty");
            if (!await ValidateUser(loginRequest))
                return StandardResponse<string>.Failed("Email not confirmed");
            var token = await CreateToken(populateExp: true);
            return StandardResponse<string>.Success("Email confirmed", token.AccessToken);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"))),
                ValidateLifetime = true,
                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"]
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out
           securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null ||
           !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
            StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }

        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
            var user = await _userManager.FindByNameAsync(principal.Identity.Name);
            /*            if (user == null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                            throw new RefreshTokenBadRequest();*/
            _user = user;
            return await CreateToken(populateExp: false);
        }
    }
}