using MediatR;
using VisualReader.Application.Models.Bases;
using VisualReader.Application.Services.Abstractions;

namespace VisualReader.Application.Users.Commands.Handlers
{
    internal class LogoutRequestHandler : IRequestHandler<LogoutRequest, ResponseBase>
    {
        private readonly IUserService _service;

        public LogoutRequestHandler(IUserService service)
        {
            _service = service;
        }

        public Task<ResponseBase> Handle(LogoutRequest request, CancellationToken cancellationToken)
        {
            return _service.LogoutAsync(request, cancellationToken);
        }
    }
}