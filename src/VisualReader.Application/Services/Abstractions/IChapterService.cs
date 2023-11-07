using VisualReader.Application.TruyenManagers.Commands.Post;

namespace VisualReader
{
    public interface IChapterService
    {
        Task<SearchResponse<ChapterDto>> GetAllChapterAsync(GetAllChapter request, CancellationToken cancellationToken);

        Task<ChapterDto> GetChapterAsyn(Guid id, CancellationToken cancellationToken);

        Task<ChapterDto> AddChapterAsync(ChapterRequest request, CancellationToken cancellationToken);

        Task<ChapterDto> EditChapterAsync(EditChapter request, CancellationToken cancellationToken);

        Task<bool> RemoveChapterAsync(Guid Id, CancellationToken cancellationToken);
    }
}