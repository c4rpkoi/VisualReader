using MediatR;

namespace VisualReader
{    public class PostReadingListItemRequestHandler : IRequestHandler<ReadingListItemRequest, ReadingListItemDto>
    {
        private readonly IReadingListItemService _service;

        public PostReadingListItemRequestHandler(IReadingListItemService service)
        {
            _service = service;
        }

        public Task<ReadingListItemDto> Handle(ReadingListItemRequest request, CancellationToken cancellationToken)
        {
            return _service.AddReadingListItemAsync(request, cancellationToken);
        }
    }
}
