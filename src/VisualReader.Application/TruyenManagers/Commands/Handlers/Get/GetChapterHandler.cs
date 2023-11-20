using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{
    public class GetChapterHandler : IRequestHandler<GetAllChapter, SearchResponse<ChapterDto>>
    {
        private readonly IChapterService _service;
        public Task<SearchResponse<ChapterDto>> Handle(GetAllChapter request, CancellationToken cancellationToken)
        {
            return _service.GetAllChapterAsync(request,cancellationToken);
        }
    }
}
