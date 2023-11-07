using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{
    public class GetTheLoaiHandler : IRequestHandler<GetAllTheLoai, SearchResponse<TheLoaiDto>>
    {
        private readonly ITheLoaiService _service;
        public Task<SearchResponse<TheLoaiDto>> Handle(GetAllTheLoai request, CancellationToken cancellationToken)
        {
            return _service.GetAllTheLoaiAsync(request, cancellationToken);
        }
    }
}
