namespace VisualReader
{
    public interface ITheLoaiService
    {
        Task<SearchResponse<TheLoaiDto>> GetAllTheLoaiAsync(GetAllTheLoai request, CancellationToken cancellationToken);

        Task<TheLoaiDto> GetTheLoaiAsyn(Guid id, CancellationToken cancellationToken);

        Task<TheLoaiDto> AddTheLoaiAsync(TheLoaiRequest request, CancellationToken cancellationToken);

        Task<TheLoaiDto> EditTheLoaiAsync(EditTheLoai request, CancellationToken cancellationToken);

        Task<bool> RemoveTheLoaiAsync(Guid Id, CancellationToken cancellationToken);
    }
}