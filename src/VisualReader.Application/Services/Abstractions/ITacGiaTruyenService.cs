using VisualReader.Application.TruyenManagers.Commands.Post;

namespace VisualReader
{
    public interface ITacGiaTruyenService
    {
        Task<SearchResponse<TacGiaTruyenDto>> GetAllTacGiaTruyenAsync(GetAllTacGiaTruyen request, CancellationToken cancellationToken);

        Task<TacGiaTruyenDto> GetTacGiaTruyenAsyn(Guid id, CancellationToken cancellationToken);

        Task<TacGiaTruyenDto> AddTacGiaTruyenAsync(TacGiaTruyenRequest request, CancellationToken cancellationToken);

        Task<TacGiaTruyenDto> EditTacGiaTruyenAsync(EditTacGiaTruyen request, CancellationToken cancellationToken);

        Task<bool> RemoveTacGiaTruyenAsync(Guid Id, CancellationToken cancellationToken);
    }
}