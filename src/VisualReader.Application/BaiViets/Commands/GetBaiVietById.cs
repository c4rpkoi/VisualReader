using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Application.BaiViets.Commands.Models;

namespace VisualReader.Application.BaiViets.Commands
{
    public class GetBaiVietById : IRequest<BaiVietDto>
    {
        public Guid Id { get; set; }

        public GetBaiVietById(Guid id) => Id = id;
    }
}
