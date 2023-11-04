using MediatR;

namespace VisualReader
{
    public class GetCommentByIdRequestHandler : IRequestHandler<GetCommentById, CommentDto>
    {
        private readonly ICommentService _service;

        public GetCommentByIdRequestHandler(ICommentService service)
        {
            _service = service;
        }

        public Task<CommentDto> Handle(GetCommentById request, CancellationToken cancellationToken)
        {
            return _service.GetCommentAsync(request.Id, cancellationToken);
        }
    }
}