namespace VisualReader
{
    public interface ITruyenService
    {
        Task<SearchResponse<TruyenDto>> GetAllTruyenAsync(GetAllTruyen request, CancellationToken cancellationToken);

        Task<TruyenDto> GetTruyenAsyn(Guid id, CancellationToken cancellationToken);

        Task<TruyenDto> AddTruyenAsync(TruyenRequest request, CancellationToken cancellationToken);

        Task<TruyenDto> EditTruyenAsync(EditTruyen request, CancellationToken cancellationToken);

        Task<bool> RemoveTruyenAsync(Guid Id, CancellationToken cancellationToken);
    }
}