using MediatR;

namespace VisualReader
{
    internal class RemoveBookmarkRequestHandler : IRequestHandler<RemoveBookmark, bool>
    {
        private readonly IBookmarkservice _service;

        public RemoveBookmarkRequestHandler(IBookmarkservice service)
        {
            _service = service;
        }

        public Task<bool> Handle(RemoveBookmark request, CancellationToken cancellationToken)
        {
            return _service.RemoveBookmarkAsync(request.Id, cancellationToken);
        }
    }
}
