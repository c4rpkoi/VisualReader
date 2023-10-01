using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VisualReader.Application.Constants;
using VisualReader.Application.Models.Bases;
using VisualReader.Application.Services.Abstractions;
using VisualReader.Application.Users.Commands.Models;

namespace VisualReader.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly ICacheService _cacheService;

        public AuthenticationService(IConfiguration configuration, ICacheService cacheService)
        {
            _configuration = configuration;
            _cacheService = cacheService;
        }

        public TokenResponse GenerateToken(string userName, string userRole)
        {
            var secretKey = _configuration["Authentication:TokenSecret"];
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, userRole),
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["Authentication:Issuer"],
                audience: _configuration["Authentication:Authority"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new TokenResponse(tokenString, "Bearer", 3600);
        }

        public UserDto GetUserByToken(string token)
        {
            var user = new UserDto();
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.ReadJwtToken(token);

            foreach (var claim in jwt.Claims)
            {
                if (claim.Type.Equals(ClaimTypes.Name))
                    user.Email = claim.Value;
                else if (claim.Type.Equals(ClaimTypes.Role))
                    user.Role = claim.Value;
            }
            return user;
        }

        public async Task<bool> RevokeTokenAsync(string token)
        {
            var blackList = await _cacheService.GetAsync<IList<string>>(RedisKeyConstant.BLACK_LIST);
            if (blackList == null)
            {
                var newBlackList = new List<string>() { token };
                await _cacheService.SetAsync(RedisKeyConstant.BLACK_LIST, newBlackList, TimeSpan.FromDays(1));
            }
            else
            {
                blackList.Add(token);
                await _cacheService.SetAsync(RedisKeyConstant.BLACK_LIST, blackList, TimeSpan.FromDays(1));
            }
            return true;
        }

        public async Task<bool> IsTokenRevoke(string token)
        {
            var blackList = await _cacheService.GetAsync<IList<string>>(RedisKeyConstant.BLACK_LIST);
            if (blackList == null || !blackList.Any())
                return false;

            return blackList.Contains(token);
        }
    }
}