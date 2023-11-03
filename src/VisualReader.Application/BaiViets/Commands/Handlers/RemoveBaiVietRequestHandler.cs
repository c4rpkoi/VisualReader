using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Application.Services.Abstractions;

namespace VisualReader.Application.BaiViets.Commands.Handlers
{
    public class RemoveBaiVietRequestHandler : IRequestHandler<RemoveBaiViet, bool>
    {
        private readonly IBaiVietService _service;
        public RemoveBaiVietRequestHandler(IBaiVietService service)
        {
            _service = service;
        }
        public Task<bool> Handle(RemoveBaiViet request, CancellationToken cancellationToken)
        {
            return _service.RemoveBaiVietAsync(request.Id, cancellationToken);
        }
    }
}
