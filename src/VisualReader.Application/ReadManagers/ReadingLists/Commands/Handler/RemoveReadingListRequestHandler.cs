using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader { 
    internal class RemoveReadingListRequestHandler : IRequestHandler<RemoveReadingList, bool>
    {
        private readonly IReadingListService _service;

        public RemoveReadingListRequestHandler(IReadingListService service)
        {
            _service = service;
        }

        public Task<bool> Handle(RemoveReadingList request, CancellationToken cancellationToken)
    {
            return _service.RemoveReadingListAsync(request.Id, cancellationToken);
        }
    }
}
