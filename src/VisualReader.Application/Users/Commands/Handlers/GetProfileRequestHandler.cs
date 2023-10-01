using MediatR;
using VisualReader.Application.Services.Abstractions;
using VisualReader.Application.Users.Commands.Models;

namespace VisualReader.Application.Users.Commands.Handlers
{
    public class GetProfileRequestHandler : IRequestHandler<GetProfileRequest, GetProfileResponse>
    {
        private readonly IUserService _service;

        public GetProfileRequestHandler(IUserService service)
        {
            _service = service;
        }

        public Task<GetProfileResponse> Handle(GetProfileRequest request, CancellationToken cancellationToken)
        {
            return _service.GetProfileAsync(request, cancellationToken);
        }
    }
}