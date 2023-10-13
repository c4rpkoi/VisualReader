using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Application.Comments.Commands.Models;
using VisualReader.Application.Services.Abstractions;

namespace VisualReader.Application.Comments.Commands.Handlers
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
