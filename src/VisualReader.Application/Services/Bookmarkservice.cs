namespace VisualReader
{
    public class Bookmarkservice : IBookmarkservice
    {
        private readonly IUnitOfWork _unitOfWork;

        public Bookmarkservice(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BookmarkDto> AddBookmarkAsync(BookmarkRequest request, CancellationToken cancellationToken)
        {
            var bookmark = BookmarkRequest.Create(request);
            try
            {
                if (string.IsNullOrEmpty(bookmark.PageIndex))
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.Bookmarks.AddAsync(bookmark);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return BookmarkDto.Create(bookmark);
        }

        public async Task<bool> RemoveBookmarkAsync(Guid Id, CancellationToken cancellationToken)
        {
            try
            {
                var currentcmt = await _unitOfWork.Bookmarks.FindAsync(Id);
                if (currentcmt == null)
                {
                    throw new EntityNotFoundException();
                }
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.Bookmarks.RemoveAsync(currentcmt.Id);
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
