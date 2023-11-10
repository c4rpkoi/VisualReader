using Microsoft.EntityFrameworkCore;

namespace VisualReader
{
    public class LoaiTruyenCuaTruyenService : ILoaiTruyenCuaTruyenService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoaiTruyenCuaTruyenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<LoaiTruyenCuaTruyenDto> AddLoaiTruyenCuaTruyenAsync(LoaiTruyenCuaTruyenRequest request, CancellationToken cancellationToken)
        {
            var data = LoaiTruyenCuaTruyenRequest.Create(request);
            try
            {
                if (data.Id == null)
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.LoaiTruyenCuaTruyens.AddAsync(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return LoaiTruyenCuaTruyenDto.Create(data);
        }

        public async Task<LoaiTruyenCuaTruyenDto> EditLoaiTruyenCuaTruyenAsync(EditLoaiTruyenCuaTruyen request, CancellationToken cancellationToken)
        {
            var data = EditLoaiTruyenCuaTruyen.Edit(request);
            try
            {
                var currentdata = await _unitOfWork.LoaiTruyenCuaTruyens.FindAsync(request.Id);
                if (currentdata == null)
                {
                    throw new EntityNotFoundException();
                }
                if (currentdata == null)
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.LoaiTruyenCuaTruyens.AddAsync(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return LoaiTruyenCuaTruyenDto.Create(data);
        }

        public async Task<SearchResponse<LoaiTruyenCuaTruyenDto>> GetAllLoaiTruyenCuaTruyenAsync(GetAllLoaiTruyenCuaTruyen request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.LoaiTruyenCuaTruyens.AsQueryable()
                .AsNoTracking().OrderBy(x => x.CreatedUtc);
            var command = query.Select(x => LoaiTruyenCuaTruyenDto.Create(x));
            return await command.SearchAsync(request);
        }

        public async Task<LoaiTruyenCuaTruyenDto> GetLoaiTruyenCuaTruyenAsyn(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.LoaiTruyenCuaTruyens.AsQueryable().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException();
            }
            return LoaiTruyenCuaTruyenDto.Create(entity);
        }

        public async Task<bool> RemoveLoaiTruyenCuaTruyenAsync(Guid Id, CancellationToken cancellationToken)
        {
            try
            {
                var currentdata = await _unitOfWork.LoaiTruyenCuaTruyens.FindAsync(Id);
                if (currentdata == null)
                {
                    throw new EntityNotFoundException();
                }
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.LoaiTruyenCuaTruyens.RemoveAsync(currentdata.Id);
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