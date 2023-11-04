using MediatR;

namespace VisualReader
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