using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{
    public class RemoveBlockRequestHandler : IRequestHandler<RemoveBlock, bool>
    {
        private readonly IBlockService _service;

        public RemoveBlockRequestHandler(IBlockService service)
        {
            _service = service;
        }

        public Task<bool> Handle(RemoveBlock request, CancellationToken cancellationToken)
        {
            return _service.RemoveBlockAsync(request.Id, cancellationToken);
        }
    }
}
