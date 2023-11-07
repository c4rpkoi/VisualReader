using VisualReader.Application.TruyenManagers.Commands.Post;

namespace VisualReader
{
    public interface ILoaiTruyenService
    {
        Task<SearchResponse<LoaiTruyenDto>> GetAllLoaiTruyenAsync(GetAllLoaiTruyen request, CancellationToken cancellationToken);

        Task<LoaiTruyenDto> GetLoaiTruyenAsyn(Guid id, CancellationToken cancellationToken);

        Task<LoaiTruyenDto> AddLoaiTruyenAsync(LoaiTruyenRequest request, CancellationToken cancellationToken);

        Task<LoaiTruyenDto> EditLoaiTruyenAsync(EditLoaiTruyen request, CancellationToken cancellationToken);

        Task<bool> RemoveLoaiTruyenAsync(Guid Id, CancellationToken cancellationToken);
    }
}