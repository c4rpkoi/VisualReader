using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{
    public class GetTruyenHandler : IRequestHandler<GetAllTruyen, SearchResponse<TruyenDto>>
    {
        private readonly ITruyenService _service;
        public Task<SearchResponse<TruyenDto>> Handle(GetAllTruyen request, CancellationToken cancellationToken)
        {
            return _service.GetAllTruyenAsync(request, cancellationToken);
        }
    }
}
