using MediatR;

namespace VisualReader
{
    public class PostBlockRequestHandler : IRequestHandler<BlockRequest, BlockDto>
    {
        private readonly IBlockService _service;

        public PostBlockRequestHandler(IBlockService service)
        {
            _service = service;
        }

        public Task<BlockDto> Handle(BlockRequest request, CancellationToken cancellationToken)
        {
            return _service.AddBlockAsync(request, cancellationToken);
        }
    }
}
