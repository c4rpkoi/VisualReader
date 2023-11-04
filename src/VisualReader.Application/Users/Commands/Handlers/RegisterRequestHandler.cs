using MediatR;

namespace VisualReader
{
    public class RegisterRequestHandler : IRequestHandler<RegisterRequest, RegisterResponse>
    {
        private readonly IUserService _service;

        public RegisterRequestHandler(IUserService service)
        {
            _service = service;
        }

        public Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            return _service.RegisterAsync(request, cancellationToken);
        }
    }
}