using MediatR;

namespace VisualReader
{
    public class LoginRequestHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IUserService _service;

        public LoginRequestHandler(IUserService service)
        {
            _service = service;
        }

        public Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            return _service.LoginAsync(request, cancellationToken);
        }
    }
}