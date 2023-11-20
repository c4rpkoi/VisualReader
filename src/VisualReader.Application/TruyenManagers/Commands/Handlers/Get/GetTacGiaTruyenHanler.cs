using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{
    public class GetTacGiaTruyenHanler : IRequestHandler<GetAllTacGiaTruyen, SearchResponse<TacGiaTruyenDto>>
    {
        private readonly ITacGiaTruyenService _service;
        public Task<SearchResponse<TacGiaTruyenDto>> Handle(GetAllTacGiaTruyen request, CancellationToken cancellationToken)
        {
            return _service.GetAllTacGiaTruyenAsync(request, cancellationToken);
        }
    }
}
