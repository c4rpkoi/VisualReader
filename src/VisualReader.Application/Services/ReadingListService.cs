using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{
    public class ReadingListService : IReadingListService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReadingListService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReadingListDto> AddReadingListAsync(ReadingListRequest request, CancellationToken cancellationToken)
        {
            var reading = ReadingListRequest.Create(request);
            try
            {
                if (string.IsNullOrEmpty(reading.IdUser.ToString()))
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.ReadingLists.AddAsync(reading);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return ReadingListDto.Create(reading);
        }

        public async Task<bool> RemoveReadingListAsync(Guid Id, CancellationToken cancellationToken)
        {
            try
            {
                var currentcmt = await _unitOfWork.ReadingLists.FindAsync(Id);
                if (currentcmt == null)
                {
                    throw new EntityNotFoundException();
                }
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.ReadingLists.RemoveAsync(currentcmt.Id);
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
