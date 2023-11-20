using Microsoft.EntityFrameworkCore;

namespace VisualReader
{
    public class TacGiaTruyenService : ITacGiaTruyenService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TacGiaTruyenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TacGiaTruyenDto> AddTacGiaTruyenAsync(TacGiaTruyenRequest request, CancellationToken cancellationToken)
        {
            var data = TacGiaTruyenRequest.Create(request);
            try
            {
                if (data.Id == null)
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.TacGiaTruyens.AddAsync(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return TacGiaTruyenDto.Create(data);
        }

        public async Task<TacGiaTruyenDto> EditTacGiaTruyenAsync(EditTacGiaTruyen request, CancellationToken cancellationToken)
        {
            var data = EditTacGiaTruyen.Edit(request);
            try
            {
                var currentdata = await _unitOfWork.TacGiaTruyens.FindAsync(request.Id);
                if (currentdata == null)
                {
                    throw new EntityNotFoundException();
                }
                if (currentdata == null)
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.TacGiaTruyens.AddAsync(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return TacGiaTruyenDto.Create(data);
        }

        public async Task<SearchResponse<TacGiaTruyenDto>> GetAllTacGiaTruyenAsync(GetAllTacGiaTruyen request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.TacGiaTruyens.AsQueryable()
    .AsNoTracking().OrderBy(x => x.CreatedUtc);
            var command = query.Select(x => TacGiaTruyenDto.Create(x));
            return await command.SearchAsync(request);
        }

        public async Task<TacGiaTruyenDto> GetTacGiaTruyenAsyn(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TacGiaTruyens.AsQueryable().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException();
            }
            return TacGiaTruyenDto.Create(entity);
        }

        public async Task<bool> RemoveTacGiaTruyenAsync(Guid Id, CancellationToken cancellationToken)
        {
            try
            {
                var currentdata = await _unitOfWork.TacGiaTruyens.FindAsync(Id);
                if (currentdata == null)
                {
                    throw new EntityNotFoundException();
                }
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.TacGiaTruyens.RemoveAsync(currentdata.Id);
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