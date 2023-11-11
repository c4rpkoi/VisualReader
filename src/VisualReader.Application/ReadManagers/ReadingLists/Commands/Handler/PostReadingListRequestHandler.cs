using MediatR;

namespace VisualReader
{
    public class PostReadingListRequestHandler : IRequestHandler<ReadingListRequest, ReadingListDto>
    {
        private readonly IReadingListService _service;

        public PostReadingListRequestHandler(IReadingListService service)
        {
            _service = service;
        }

        public Task<ReadingListDto> Handle(ReadingListRequest request, CancellationToken cancellationToken)
        {
            return _service.AddReadingListAsync(request, cancellationToken);
        }
    }
}
