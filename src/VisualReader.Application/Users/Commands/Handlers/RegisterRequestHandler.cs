using MediatR;
using VisualReader.Application.Services.Abstractions;
using VisualReader.Application.Users.Commands.Models;

namespace VisualReader.Application.Users.Commands.Handlers
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