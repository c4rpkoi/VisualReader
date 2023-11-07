using VisualReader.Application.TruyenManagers.Commands.Post;

namespace VisualReader
{
    public interface IChapterDataService
    {
        Task<SearchResponse<ChapterDataDto>> GetAllChapterDataAsync(GetAllChapterData request,CancellationToken cancellationToken);

        Task<ChapterDataDto> GetChapterDataAsyn(Guid id, CancellationToken cancellationToken);

        Task<ChapterDataDto> AddChapterDataAsync(ChapterDataRequest request, CancellationToken cancellationToken);

        Task<ChapterDataDto> EditChapterDataAsync(EditChapterData request, CancellationToken cancellationToken);

        Task<bool> RemoveChapterDataAsync(Guid Id, CancellationToken cancellationToken);
    }
}