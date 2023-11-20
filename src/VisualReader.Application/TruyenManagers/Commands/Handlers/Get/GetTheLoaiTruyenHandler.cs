using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{
    public class GetTheLoaiTruyenHandler : IRequestHandler<GetAllTheLoaiTruyen, SearchResponse<TheLoaiTruyenDto>>
    {
        private readonly ITheLoaiTruyenService _service;
        public Task<SearchResponse<TheLoaiTruyenDto>> Handle(GetAllTheLoaiTruyen request, CancellationToken cancellationToken)
        {
            return _service.GetAllTheLoaiTruyenAsync(request, cancellationToken);
        }
    }
}
