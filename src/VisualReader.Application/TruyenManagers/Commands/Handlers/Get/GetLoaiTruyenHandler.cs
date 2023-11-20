using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{
    public class GetLoaiTruyenHandler : IRequestHandler<GetAllLoaiTruyen, SearchResponse<LoaiTruyenDto>>
    {
        private readonly ILoaiTruyenService _service;
        public Task<SearchResponse<LoaiTruyenDto>> Handle(GetAllLoaiTruyen request, CancellationToken cancellationToken)
        {
            return _service.GetAllLoaiTruyenAsync(request, cancellationToken);
        }
    }
}
