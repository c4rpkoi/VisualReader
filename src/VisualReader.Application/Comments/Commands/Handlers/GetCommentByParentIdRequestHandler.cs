using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Application.Comments.Commands.Models;
using VisualReader.Application.Models.Bases;
using VisualReader.Application.Services.Abstractions;

namespace VisualReader.Application.Comments.Commands.Handlers
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
