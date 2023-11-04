using MediatR;

namespace VisualReader
{
    public class GetCommentByParentIdRequestHandler : IRequestHandler<GetCommentByParentId, SearchResponse<CommentDto>>
    {
        private readonly ICommentService _service;

        public GetCommentByParentIdRequestHandler(ICommentService service)
        {
            _service = service;
        }

        public Task<SearchResponse<CommentDto>> Handle(GetCommentByParentId request, CancellationToken cancellationToken)
        {
            return _service.GetAllCommentAsync(request, cancellationToken);
        }
    }
}