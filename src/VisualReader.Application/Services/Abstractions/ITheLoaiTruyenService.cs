namespace VisualReader
{
    public interface ITheLoaiTruyenService
    {
        Task<SearchResponse<TheLoaiTruyenDto>> GetAllTheLoaiTruyenAsync(GetAllTheLoaiTruyen request, CancellationToken cancellationToken);

        Task<TheLoaiTruyenDto> GetTheLoaiTruyenAsyn(Guid id, CancellationToken cancellationToken);

        Task<TheLoaiTruyenDto> AddTheLoaiTruyenAsync(TheLoaiTruyenRequest request, CancellationToken cancellationToken);

        Task<TheLoaiTruyenDto> EditTheLoaiTruyenAsync(EditTheLoaiTruyen request, CancellationToken cancellationToken);

        Task<bool> RemoveTheLoaiTruyenAsync(Guid Id, CancellationToken cancellationToken);
    }
}