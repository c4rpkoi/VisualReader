using Microsoft.EntityFrameworkCore;

namespace VisualReader
{
    public class TheLoaiTruyenService : ITheLoaiTruyenService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TheLoaiTruyenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TheLoaiTruyenDto> AddTheLoaiTruyenAsync(TheLoaiTruyenRequest request, CancellationToken cancellationToken)
        {
            var data = TheLoaiTruyenRequest.Create(request);
            try
            {
                if (data.Id == null)
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.TheLoaiTruyens.AddAsync(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return TheLoaiTruyenDto.Create(data);
        }

        public async Task<TheLoaiTruyenDto> EditTheLoaiTruyenAsync(EditTheLoaiTruyen request, CancellationToken cancellationToken)
        {
            var data = EditTheLoaiTruyen.Edit(request);
            try
            {
                var currentdata = await _unitOfWork.TheLoaiTruyens.FindAsync(request.Id);
                if (currentdata == null)
                {
                    throw new EntityNotFoundException();
                }
                if (currentdata == null)
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.TheLoaiTruyens.AddAsync(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return TheLoaiTruyenDto.Create(data);
        }

        public async Task<SearchResponse<TheLoaiTruyenDto>> GetAllTheLoaiTruyenAsync(GetAllTheLoaiTruyen request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.TheLoaiTruyens.AsQueryable()
    .AsNoTracking().OrderBy(x => x.CreatedUtc);
            var command = query.Select(x => TheLoaiTruyenDto.Create(x));
            return await command.SearchAsync(request);
        }

        public async Task<TheLoaiTruyenDto> GetTheLoaiTruyenAsyn(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TheLoaiTruyens.AsQueryable().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException();
            }
            return TheLoaiTruyenDto.Create(entity);
        }

        public async Task<bool> RemoveTheLoaiTruyenAsync(Guid Id, CancellationToken cancellationToken)
        {
            try
            {
                var currentdata = await _unitOfWork.TheLoaiTruyens.FindAsync(Id);
                if (currentdata == null)
                {
                    throw new EntityNotFoundException();
                }
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.TheLoaiTruyens.RemoveAsync(currentdata.Id);
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