using VisualReader.Application.Models.Bases;
using VisualReader.Application.Users.Commands.Models;

namespace VisualReader.Application.Services.Abstractions
{
    public interface IAuthenticationService
    {
        TokenResponse GenerateToken(string userName, string userRole);

        Task<bool> RevokeTokenAsync(string token);

        Task<bool> IsTokenRevoke(string token);

        UserDto GetUserByToken(string token);
    }
}