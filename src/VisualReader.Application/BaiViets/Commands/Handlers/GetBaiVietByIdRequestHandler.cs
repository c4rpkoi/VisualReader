using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Application.Comments.Commands.Models;
using VisualReader.Application.Comments.Commands;
using VisualReader.Application.Models;
using VisualReader.Application.Services.Abstractions;

namespace VisualReader
{
    public class GetBaiVietByIdRequestHandler : IRequestHandler<GetBaiVietById, BaiVietDto>
    {
        private readonly IBaiVietService _service;
        public GetBaiVietByIdRequestHandler(IBaiVietService service)
        {
            _service = service;
        }
        public Task<BaiVietDto> Handle(GetBaiVietById request, CancellationToken cancellationToken)
        {
            return _service.GetBaiVietAsync(request.Id, cancellationToken);
        }
    }
}
