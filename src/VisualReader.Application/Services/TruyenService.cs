using Microsoft.EntityFrameworkCore;

namespace VisualReader
{
    public class TruyenService : ITruyenService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TruyenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TruyenDto> AddTruyenAsync(TruyenRequest request, CancellationToken cancellationToken)
        {
            var data = TruyenRequest.Create(request);
            try
            {
                if (data.Id == null)
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.Truyens.AddAsync(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return TruyenDto.Create(data);
        }

        public async Task<TruyenDto> EditTruyenAsync(EditTruyen request, CancellationToken cancellationToken)
        {
            var data = EditTruyen.Edit(request);
            try
            {
                var currentdata = await _unitOfWork.Truyens.FindAsync(request.Id);
                if (currentdata == null)
                {
                    throw new EntityNotFoundException();
                }
                if (currentdata == null)
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.Truyens.AddAsync(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return TruyenDto.Create(data);
        }

        public async Task<SearchResponse<TruyenDto>> GetAllTruyenAsync(GetAllTruyen request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.Truyens.AsQueryable()
    .AsNoTracking().OrderBy(x => x.CreatedUtc);
            var command = query.Select(x => TruyenDto.Create(x));
            return await command.SearchAsync(request);
        }

        public async Task<TruyenDto> GetTruyenAsyn(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Truyens.AsQueryable().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException();
            }
            return TruyenDto.Create(entity);
        }

        public async Task<bool> RemoveTruyenAsync(Guid Id, CancellationToken cancellationToken)
        {
            try
            {
                var currentdata = await _unitOfWork.Truyens.FindAsync(Id);
                if (currentdata == null)
                {
                    throw new EntityNotFoundException();
                }
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.Truyens.RemoveAsync(currentdata.Id);
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