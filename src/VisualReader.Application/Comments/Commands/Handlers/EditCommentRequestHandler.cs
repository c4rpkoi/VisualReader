using MediatR;

namespace VisualReader
{
    public class EditCommentRequestHandler : IRequestHandler<EditComment, CommentDto>
    {
        private readonly ICommentService _service;

        public EditCommentRequestHandler(ICommentService service)
        {
            _service = service;
        }

        public Task<CommentDto> Handle(EditComment request, CancellationToken cancellationToken)
        {
            return _service.EditCommentAsync(request, cancellationToken);
        }
    }
}