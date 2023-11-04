using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Application.BaiViets.Commands;
using VisualReader.Application.BaiViets.Commands.Models;
using VisualReader.Application.Services.Abstractions;

namespace VisualReader
{ 
    public class EditBaiVietRequestHandler : IRequestHandler<EditBaiViet, BaiVietDto>
    {
        private readonly IBaiVietService _service;
        public EditBaiVietRequestHandler(IBaiVietService service)
        {
            _service = service;
        }
        public Task<BaiVietDto> Handle(EditBaiViet request, CancellationToken cancellationToken)
        {
            return _service.EditBaiVietAsync(request, cancellationToken);
        }
    }
}
