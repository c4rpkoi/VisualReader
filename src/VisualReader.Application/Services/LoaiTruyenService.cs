using Microsoft.EntityFrameworkCore;

namespace VisualReader
{
    public class LoaiTruyenService : ILoaiTruyenService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoaiTruyenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<LoaiTruyenDto> AddLoaiTruyenAsync(LoaiTruyenRequest request, CancellationToken cancellationToken)
        {
            var data = LoaiTruyenRequest.Create(request);
            try
            {
                if (data.Id == null)
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.LoaiTruyens.AddAsync(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return LoaiTruyenDto.Create(data);
        }

        public async Task<LoaiTruyenDto> EditLoaiTruyenAsync(EditLoaiTruyen request, CancellationToken cancellationToken)
        {
            var data = EditLoaiTruyen.Edit(request);
            try
            {
                if (data.Id == null)
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.LoaiTruyens.AddAsync(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return LoaiTruyenDto.Create(data);
        }

        public async Task<SearchResponse<LoaiTruyenDto>> GetAllLoaiTruyenAsync(GetAllLoaiTruyen request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.LoaiTruyens.AsQueryable()
    .AsNoTracking().OrderBy(x => x.CreatedUtc);
            var command = query.Select(x => LoaiTruyenDto.Create(x));
            return await command.SearchAsync(request);
        }

        public async Task<LoaiTruyenDto> GetLoaiTruyenAsyn(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.LoaiTruyens.AsQueryable().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException();
            }
            return LoaiTruyenDto.Create(entity);
        }

        public async Task<bool> RemoveLoaiTruyenAsync(Guid Id, CancellationToken cancellationToken)
        {
            try
            {
                var currentdata = await _unitOfWork.LoaiTruyens.FindAsync(Id);
                if (currentdata == null)
                {
                    throw new EntityNotFoundException();
                }
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.LoaiTruyens.RemoveAsync(currentdata.Id);
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