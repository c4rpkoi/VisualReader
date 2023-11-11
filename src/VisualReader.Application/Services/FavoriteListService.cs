namespace VisualReader.Application.Services
{
    public class FavoriteListService : IFavoriteListService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FavoriteListService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async     Task<FavoriteListDto> AddFavoriteListAsync(FavoriteListRequest request, CancellationToken cancellationToken)
        {
            var favorite = FavoriteListRequest.Create(request);
            try
            {
                if (string.IsNullOrEmpty(favorite.IdTruyen.ToString()))
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.FavoriteLists.AddAsync(favorite);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return FavoriteListDto.Create(favorite);
        }

        public async Task<bool> RemoveFavoriteListAsync(Guid Id, CancellationToken cancellationToken)
        {
            try
            {
                var currentcmt = await _unitOfWork.FavoriteLists.FindAsync(Id);
                if (currentcmt == null)
                {
                    throw new EntityNotFoundException();
                }
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.FavoriteLists.RemoveAsync(currentcmt.Id);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }
    }
}
