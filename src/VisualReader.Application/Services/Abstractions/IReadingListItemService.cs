using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader { 
    public   interface IReadingListItemService
    {
        //Task<SearchResponse<CommentDto>> GetAllCommentAsync(GetCommentByParentId request, CancellationToken cancellationToken);//read lấy danh sách cmt theo id cần lấy

       // Task<CommentDto> GetCommentAsync(Guid id, CancellationToken cancellationToken);// get 1 comment

        Task<ReadingListItemDto> AddReadingListItemAsync(ReadingListItemRequest request, CancellationToken cancellationToken);// thêm 1 cmt

      //  Task<CommentDto> EditCommentAsync(EditComment request, CancellationToken cancellationToken);// update 1 cmt

        Task<bool> RemoveReadingListItemAsync(Guid Id, CancellationToken cancellationToken);// x

    }
}
