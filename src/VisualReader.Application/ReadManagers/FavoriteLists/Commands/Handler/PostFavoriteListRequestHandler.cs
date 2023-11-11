using MediatR;

namespace VisualReader
{
    public class PostFavoriteListRequestHandler : IRequestHandler<FavoriteListRequest, FavoriteListDto>
    {
        private readonly IFavoriteListService _service;

        public PostFavoriteListRequestHandler(IFavoriteListService service)
        {
            _service = service;
        }

        public Task<FavoriteListDto> Handle(FavoriteListRequest request, CancellationToken cancellationToken)
        {
            return _service.AddFavoriteListAsync(request, cancellationToken);
        }
    }
}
