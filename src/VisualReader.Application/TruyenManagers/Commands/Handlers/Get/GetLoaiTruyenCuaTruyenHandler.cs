using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{
    public class GetLoaiTruyenCuaTruyenHandler : IRequestHandler<GetAllLoaiTruyenCuaTruyen, SearchResponse<LoaiTruyenCuaTruyenDto>>
    {
        private readonly ILoaiTruyenCuaTruyenService _service;
        public Task<SearchResponse<LoaiTruyenCuaTruyenDto>> Handle(GetAllLoaiTruyenCuaTruyen request, CancellationToken cancellationToken)
        {
            return _service.GetAllLoaiTruyenCuaTruyenAsync(request, cancellationToken);
        }
    }
}
