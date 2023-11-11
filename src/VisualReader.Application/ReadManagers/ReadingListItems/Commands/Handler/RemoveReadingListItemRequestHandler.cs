using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{
    internal class RemoveReadingListItemRequestHandler : IRequestHandler<RemoveReadingListItem, bool>
    {
        private readonly IReadingListItemService _service;

        public RemoveReadingListItemRequestHandler(IReadingListItemService service)
        {
            _service = service;
        }

        public Task<bool> Handle(RemoveReadingListItem request, CancellationToken cancellationToken)
        {
            return _service.RemoveReadingListItemAsync(request.Id, cancellationToken);
        }
    }
}
