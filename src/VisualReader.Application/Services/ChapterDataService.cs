using Microsoft.EntityFrameworkCore;

namespace VisualReader
{
    public class ChapterDataService : IChapterDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IChapterRepository _chapterRepository;

        public ChapterDataService(IUnitOfWork unitOfWork, IChapterRepository chapterRepository)
        {
            _unitOfWork = unitOfWork;
            _chapterRepository = chapterRepository;
        }

        public async Task<ChapterDataDto> AddChapterDataAsync(ChapterDataRequest request, CancellationToken cancellationToken)
        {
            var data = ChapterDataRequest.Create(request);
            try
            {
                if (data.Data == null)
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.ChapterDatas.AddAsync(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return ChapterDataDto.Create(data);
        }

        public async Task<ChapterDataDto> EditChapterDataAsync(EditChapterData request, CancellationToken cancellationToken)
        {
            var data = EditChapterData.Edit(request);
            try
            {
                var currentdata = await _unitOfWork.ChapterDatas.FindAsync(request.Id);
                if (currentdata == null)
                {
                    throw new EntityNotFoundException();
                }
                if (currentdata == null)
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.ChapterDatas.AddAsync(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return ChapterDataDto.Create(data);
        }

        public async Task<SearchResponse<ChapterDataDto>> GetAllChapterDataAsync(GetAllChapterData request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.ChapterDatas.AsQueryable()
                .AsNoTracking().OrderBy(x => x.CreatedUtc);
            var command = query.Select(x => ChapterDataDto.Create(x));
            return await command.SearchAsync(request);
        }

        public async Task<ChapterDataDto> GetChapterDataAsyn(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ChapterDatas.AsQueryable().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException();
            }
            return ChapterDataDto.Create(entity);
        }

        public async Task<bool> RemoveChapterDataAsync(Guid Id, CancellationToken cancellationToken)
        {
            try
            {
                var currentdata = await _unitOfWork.ChapterDatas.FindAsync(Id);
                if (currentdata == null)
                {
                    throw new EntityNotFoundException();
                }
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.ChapterDatas.RemoveAsync(currentdata.Id);
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