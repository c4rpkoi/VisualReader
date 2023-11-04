using MediatR;

namespace VisualReader
{
    public class PostCommentRequestHandler : IRequestHandler<CommentRequest, CommentDto>
    {
        private readonly ICommentService _service;

        public PostCommentRequestHandler(ICommentService service)
        {
            _service = service;
        }

        public Task<CommentDto> Handle(CommentRequest request, CancellationToken cancellationToken)
        {
            return _service.AddCommentAsync(request, cancellationToken);
        }
    }
}