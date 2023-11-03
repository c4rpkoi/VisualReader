using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Application.BaiViets.Commands.Models;
using VisualReader.Application.Comments.Commands.Models;
using VisualReader.Application.Comments.Commands;
using VisualReader.Application.BaiViets.Commands;

namespace VisualReader.Application.Services.Abstractions
{
    public interface IBaiVietService
    {
        Task<BaiVietDto> AddBaiVietAsync(BaiVietRequest request, CancellationToken cancellationToken);
        Task<BaiVietDto> EditBaiVietAsync(EditBaiViet request, CancellationToken cancellationToken);
        Task<BaiVietDto> GetBaiVietAsync(Guid id, CancellationToken cancellationToken);
        Task<CommentDto> EditCommentAsync(EditComment request, CancellationToken cancellationToken);
        Task<bool> RemoveBaiVietAsync(Guid id, CancellationToken cancellationToken);
    }
}
