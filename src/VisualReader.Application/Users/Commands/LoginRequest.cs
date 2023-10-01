using MediatR;
using VisualReader.Application.Constants;
using VisualReader.Application.Users.Commands.Models;

namespace VisualReader.Application.Users.Commands
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; } = UserTypeConstant.LOCAL_USER;
    }
}