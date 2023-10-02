using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Application.Comments.Commands.Models;

namespace VisualReader.Application.Comments.Commands
{
    public class RemoveComment:IRequest<bool>//cái bool để trong Irequest là kiểu trả về nhá
    {
        public Guid Id { get; set; }
        public RemoveComment(Guid id) => Id = id;
    }
}
