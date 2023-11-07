using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{
    public class GetTacGiaHandler : IRequestHandler<GetAllTacGia, SearchResponse<TacGiaDto>>
    {
        private readonly ITacGiaService _service;
        public Task<SearchResponse<TacGiaDto>> Handle(GetAllTacGia request, CancellationToken cancellationToken)
        {
            return _service.GetAllTacGiaAsync(request, cancellationToken);
        }
    }
}
