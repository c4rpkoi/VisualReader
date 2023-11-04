using MediatR;

namespace VisualReader
{
    public class RemoveCommentRequestHandler : IRequestHandler<RemoveComment, bool>
    {
        private readonly ICommentService _service;

        public RemoveCommentRequestHandler(ICommentService service)
        {
            _service = service;
        }

        public Task<bool> Handle(RemoveComment request, CancellationToken cancellationToken)
        {
            return _service.RemoveCommentAsync(request.Id, cancellationToken);
        }
    }
}