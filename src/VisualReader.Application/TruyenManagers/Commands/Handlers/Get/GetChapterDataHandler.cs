using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{
    public class GetChapterDataHandler : IRequestHandler<GetAllChapterData, SearchResponse<ChapterDataDto>>
    {
        private readonly IChapterDataService _service;
        public Task<SearchResponse<ChapterDataDto>> Handle(GetAllChapterData request, CancellationToken cancellationToken)
        {
            return _service.GetAllChapterDataAsync(request,cancellationToken);
        }
    }
}
