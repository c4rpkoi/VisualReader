using MediatR;

namespace VisualReader
{
    public class PostBookmarkRequestHandler : IRequestHandler<BookmarkRequest, BookmarkDto>
    {
        private readonly IBookmarkservice _service;
        public PostBookmarkRequestHandler(IBookmarkservice service)
        {
            _service = service;
        }

        public Task<BookmarkDto> Handle(BookmarkRequest request, CancellationToken cancellationToken)
        {
            return _service.AddBookmarkAsync(request, cancellationToken);
        }
    }
}
