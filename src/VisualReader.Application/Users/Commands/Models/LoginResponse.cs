using VisualReader.Application.Models.Bases;

namespace VisualReader.Application.Users.Commands.Models
{
    public class LoginResponse : ResponseBase
    {
        public string AccessToken { get; set; }
        public string UrlRedirect { get; set; }

        public LoginResponse(bool isSuccess, string token, string urlRedirect)
        {
            IsSuccess = isSuccess;
            AccessToken = token;
            UrlRedirect = urlRedirect;
        }
    }
}