using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader.Application.Services
{
    public class ReadingListItemService : IReadingListItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReadingListItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReadingListItemDto> AddReadingListItemAsync(ReadingListItemRequest request, CancellationToken cancellationToken)
        {
            var reading = ReadingListItemRequest.Create(request);
            try
            {
                if (string.IsNullOrEmpty(reading.PageIndex.ToString()))
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.ReadingListItems.AddAsync(reading);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return ReadingListItemDto.Create(reading);
        }

        public async Task<bool> RemoveReadingListItemAsync(Guid Id, CancellationToken cancellationToken)
        {
            try
            {
                var currentcmt = await _unitOfWork.ReadingListItems.FindAsync(Id);
                if (currentcmt == null)
                {
                    throw new EntityNotFoundException();
                }
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.ReadingListItems.RemoveAsync(currentcmt.Id);
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
