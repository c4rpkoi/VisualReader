using MediatR;

namespace VisualReader
{
    public class UpdateProfileRequestHandler : IRequestHandler<UpdateProfileRequest, bool>
    {
        private readonly IUserService _service;

        public UpdateProfileRequestHandler(IUserService service)
        {
            _service = service;
        }

        public Task<bool> Handle(UpdateProfileRequest request, CancellationToken cancellationToken)
        {
            return _service.UpdateProfileAsync(request, cancellationToken);
        }
    }
}