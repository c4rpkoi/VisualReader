using Microsoft.EntityFrameworkCore;

namespace VisualReader
{
    public class ChapterService : IChapterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChapterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ChapterDto> AddChapterAsync(ChapterRequest request, CancellationToken cancellationToken)
        {
            var data = ChapterRequest.Create(request);
            try
            {
                if (data.Id == null)
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.Chapters.AddAsync(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return ChapterDto.Create(data);
        }

        public async Task<ChapterDto> EditChapterAsync(EditChapter request, CancellationToken cancellationToken)
        {
            var data = EditChapter.Edit(request);
            try
            {
                var currentdata = await _unitOfWork.Chapters.FindAsync(request.Id);
                if (currentdata == null)
                {
                    throw new EntityNotFoundException();
                }
                if (currentdata == null)
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.Chapters.AddAsync(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return ChapterDto.Create(data);
        }

        public async Task<SearchResponse<ChapterDto>> GetAllChapterAsync(GetAllChapter request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.Chapters.AsQueryable()
                .AsNoTracking().OrderBy(x => x.CreatedUtc);
            var command = query.Select(x => ChapterDto.Create(x));
            return await command.SearchAsync(request);
        }

        public async Task<ChapterDto> GetChapterAsyn(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Chapters.AsQueryable().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException();
            }
            return ChapterDto.Create(entity);
        }

        public async Task<bool> RemoveChapterAsync(Guid Id, CancellationToken cancellationToken)
        {
            try
            {
                var currentdata = await _unitOfWork.Chapters.FindAsync(Id);
                if (currentdata == null)
                {
                    throw new EntityNotFoundException();
                }
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.Chapters.RemoveAsync(currentdata.Id);
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