using MediatR;

namespace VisualReader
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; } = UserTypeConstant.LOCAL_USER;
    }
}