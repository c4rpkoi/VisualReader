using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Application.Services.Abstractions;

namespace VisualReader.Application.Comments.Commands.Handlers
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
