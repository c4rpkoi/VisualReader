using Microsoft.EntityFrameworkCore;

namespace VisualReader
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserContext _userContext;
        private readonly IUserService _userService;

        public CommentService(IUnitOfWork unitOfWork, IAuthenticationService authenticationService, IUserContext userContext, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _authenticationService = authenticationService;
            _userContext = userContext;
            _userService = userService;
        }

        public async Task<CommentDto> AddCommentAsync(CommentRequest request, CancellationToken cancellationToken)
        {
            var comment = CommentRequest.Create(request);
            try
            {
                if (string.IsNullOrEmpty(comment.Content))
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.Comments.AddAsync(comment);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return CommentDto.Create(comment);
        }

        public async Task<CommentDto> EditCommentAsync(EditComment request, CancellationToken cancellationToken)
        {
            var comment = EditComment.Create(request);
            try
            {
                var currentcmt = await _unitOfWork.Comments.FindAsync(request.Id);
                if (currentcmt == null)
                {
                    throw new EntityNotFoundException();
                }
                if (comment.Content == null)
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.Comments.UpdateAsync(currentcmt.Id, comment);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return CommentDto.Create(comment);
        }

        public async Task<SearchResponse<CommentDto>> GetAllCommentAsync(GetCommentByParentId request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.Comments.AsQueryable()
                .AsNoTracking().Include(x => x.Post)
                .Include(x => x.Chapter).Include(x => x.Book)
                .Include(x => x.User).OrderBy(x => x.CreatedUtc);
            var command = query.Select(x => CommentDto.Create(x));
            return await command.SearchAsync(request);
        }

        public async Task<CommentDto> GetCommentAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Comments.AsQueryable().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException();
            }
            return CommentDto.Create(entity);
        }

        public async Task<bool> RemoveCommentAsync(Guid Id, CancellationToken cancellationToken)
        {
            try
            {
                var currentcmt = await _unitOfWork.Comments.FindAsync(Id);
                if (currentcmt == null)
                {
                    throw new EntityNotFoundException();
                }
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.Comments.RemoveAsync(currentcmt.Id);
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