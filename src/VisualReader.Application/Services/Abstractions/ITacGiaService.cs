using VisualReader.Application.TruyenManagers.Commands.Post;

namespace VisualReader
{
    public interface ITacGiaService
    {
        Task<SearchResponse<TacGiaDto>> GetAllTacGiaAsync(GetAllTacGia request, CancellationToken cancellationToken);

        Task<TacGiaDto> GetTacGiaAsyn(Guid id, CancellationToken cancellationToken);

        Task<TacGiaDto> AddTacGiaAsync(TacGiaRequest request, CancellationToken cancellationToken);

        Task<TacGiaDto> EditTacGiaAsync(EditTacGia request, CancellationToken cancellationToken);

        Task<bool> RemoveTacGiaAsync(Guid Id, CancellationToken cancellationToken);
    }
}