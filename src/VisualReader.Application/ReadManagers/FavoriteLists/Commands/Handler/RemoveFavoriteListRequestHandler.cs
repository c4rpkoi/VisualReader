using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader {
    internal class RemoveFavoriteListRequestHandler : IRequestHandler<RemoveFavoriteList, bool>
    {
        private readonly IFavoriteListService _service;

        public RemoveFavoriteListRequestHandler(IFavoriteListService service)
        {
            _service = service;
        }

        public Task<bool> Handle(RemoveFavoriteList request, CancellationToken cancellationToken)
        {
            return _service.RemoveFavoriteListAsync(request.Id, cancellationToken);
        }
    }
}
