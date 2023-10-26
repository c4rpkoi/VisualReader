using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Application.Comments.Commands.Models;
using VisualReader.Application.Comments.Commands;
using VisualReader;
using VisualReader.Application.Services.Abstractions;

namespace VisualReader
{
    public class PostBaiVietRequestHandler : IRequestHandler<BaiVietRequest, BaiVietDto>
    {
        private readonly IBaiVietService _service;
        public PostBaiVietRequestHandler(IBaiVietService service)
        {
            _service = service;
        }
        public Task<BaiVietDto> Handle(BaiVietRequest request, CancellationToken cancellationToken)
        {
            return _service.AddBaiVietAsync(request, cancellationToken);
        }
    }
}
