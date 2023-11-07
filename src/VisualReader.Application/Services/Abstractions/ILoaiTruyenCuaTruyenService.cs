using VisualReader.Application.TruyenManagers.Commands.Post;

namespace VisualReader
{
    public interface ILoaiTruyenCuaTruyenService
    {
        Task<SearchResponse<LoaiTruyenCuaTruyenDto>> GetAllLoaiTruyenCuaTruyenAsync(GetAllLoaiTruyenCuaTruyen request, CancellationToken cancellationToken);

        Task<LoaiTruyenCuaTruyenDto> GetLoaiTruyenCuaTruyenAsyn(Guid id, CancellationToken cancellationToken);

        Task<LoaiTruyenCuaTruyenDto> AddLoaiTruyenCuaTruyenAsync(LoaiTruyenCuaTruyenRequest request, CancellationToken cancellationToken);

        Task<LoaiTruyenCuaTruyenDto> EditLoaiTruyenCuaTruyenAsync(EditLoaiTruyenCuaTruyen request, CancellationToken cancellationToken);

        Task<bool> RemoveLoaiTruyenCuaTruyenAsync(Guid Id, CancellationToken cancellationToken);
    }
}