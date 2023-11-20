using Microsoft.EntityFrameworkCore;

namespace VisualReader
{
    public class TheLoaiService : ITheLoaiService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TheLoaiService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TheLoaiDto> AddTheLoaiAsync(TheLoaiRequest request, CancellationToken cancellationToken)
        {
            var data = TheLoaiRequest.Create(request);
            try
            {
                if (data.Id == null)
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.TheLoais.AddAsync(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return TheLoaiDto.Create(data);
        }

        public async Task<TheLoaiDto> EditTheLoaiAsync(EditTheLoai request, CancellationToken cancellationToken)
        {
            var data = EditTheLoai.Edit(request);
            try
            {
                var currentdata = await _unitOfWork.TheLoais.FindAsync(request.Id);
                if (currentdata == null)
                {
                    throw new EntityNotFoundException();
                }
                if (currentdata == null)
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.TheLoais.AddAsync(data);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return TheLoaiDto.Create(data);
        }

        public async Task<SearchResponse<TheLoaiDto>> GetAllTheLoaiAsync(GetAllTheLoai request, CancellationToken cancellationToken)
        {
            var query = _unitOfWork.TheLoais.AsQueryable()
                .AsNoTracking().OrderBy(x => x.CreatedUtc);
            var command = query.Select(x => TheLoaiDto.Create(x));
            return await command.SearchAsync(request);
        }

        public async Task<TheLoaiDto> GetTheLoaiAsyn(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.TheLoais.AsQueryable().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException();
            }
            return TheLoaiDto.Create(entity);
        }

        public async Task<bool> RemoveTheLoaiAsync(Guid Id, CancellationToken cancellationToken)
        {
            try
            {
                var currentdata = await _unitOfWork.TheLoais.FindAsync(Id);
                if (currentdata == null)
                {
                    throw new EntityNotFoundException();
                }
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.TheLoais.RemoveAsync(currentdata.Id);
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