using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{

    public class BlockService : IBlockService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlockService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  async Task<BlockDto> AddBlockAsync(BlockRequest request, CancellationToken cancellationToken)
        {
            var block = BlockRequest.Create(request);
            try
            {
                if (string.IsNullOrEmpty(block.IdTruyen.ToString()))
                {
                    throw new EntityValidationException(ExceptionErrorCode.ERROR_ENTITY_VALIDATION);
                }

                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.Blocks.AddAsync(block);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return BlockDto.Create(block);
        }

        public async Task<bool> RemoveBlockAsync(Guid Id, CancellationToken cancellationToken)
        {
            try
            {
                var currentcmt = await _unitOfWork.Blocks.FindAsync(Id);
                if (currentcmt == null)
                {
                    throw new EntityNotFoundException();
                }
                await _unitOfWork.BeginTransactionAsync();
                await _unitOfWork.Blocks.RemoveAsync(currentcmt.Id);
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
