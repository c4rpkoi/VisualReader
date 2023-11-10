using Microsoft.EntityFrameworkCore;

namespace VisualReader
{
    public class TacGiaService : ITacGiaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TacGiaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TacGiaDto> AddTacGiaAsync(TacGiaRequest request, CancellationToken cancellationToken)
        {
            var data = TacGiaRequest.Create(request);
            try
            {
                if (data.Id == null)
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.TacGias.AddAsync(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return TacGiaDto.Create(data);
        }

        public async Task<TacGiaDto> EditTacGiaAsync(EditTacGia request, CancellationToken cancellationToken)
        {
            var data = EditTacGia.Edit(request);
            try
            {
                var currentdata = await _unitOfWork.TacGias.FindAsync(request.Id);
                if (currentdata == null)
                {
                    throw new EntityNotFoundException();
                }
                if (currentdata == null)
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.TacGias.AddAsync(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return TacGiaDto.Create(data);
        }

        public async Task<SearchResponse<TacGiaDto>> GetAllTacGiaAsync(GetAllTacGia request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.TacGias.AsQueryable()
    .AsNoTracking().OrderBy(x => x.CreatedUtc);
            var command = query.Select(x => TacGiaDto.Create(x));
            return await command.SearchAsync(request);
        }

        public async Task<TacGiaDto> GetTacGiaAsyn(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TacGias.AsQueryable().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException();
            }
            return TacGiaDto.Create(entity);
        }

        public async Task<bool> RemoveTacGiaAsync(Guid Id, CancellationToken cancellationToken)
        {
            try
            {
                var currentdata = await _unitOfWork.TacGias.FindAsync(Id);
                if (currentdata == null)
                {
                    throw new EntityNotFoundException();
                }
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.TacGias.RemoveAsync(currentdata.Id);
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