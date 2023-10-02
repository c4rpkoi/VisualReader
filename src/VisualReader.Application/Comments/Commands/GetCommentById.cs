using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Application.Comments.Commands.Models;

namespace VisualReader.Application.Comments.Commands
{
    public class GetCommentById : IRequest<CommentDto>
    {
        public Guid Id { get; set; }

        public GetCommentById(Guid id) => Id = id;

    }
}
