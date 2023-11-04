using Microsoft.AspNetCore.Http;

namespace VisualReader
{
    public interface IUserService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken);

        Task<ResponseBase> LogoutAsync(LogoutRequest request, CancellationToken cancellationToken);

        Task<User> GetUserByEmailAsync(string userName);

        bool CheckLoginSuccess(string password, string passwordRequest);

        Task<RegisterResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken);

        Task<bool> ProcessSendEmailAsync(Guid id, string email);

        Task<bool> VerifyAccountAsync(VerifyRequest request, CancellationToken cancellationToken);

        Task<bool> UpdateProfileAsync(UpdateProfileRequest request, CancellationToken cancellationToken);

        Task<GetProfileResponse> GetProfileAsync(GetProfileRequest request, CancellationToken cancellationToken);

        Task<string> ConvertImageToBase64Async(IFormFile imageFile);
    }
}