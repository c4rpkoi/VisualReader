﻿namespace VisualReader
{
    public interface ICommentService
    {
        Task<SearchResponse<CommentDto>> GetAllCommentAsync(GetCommentByParentId request, CancellationToken cancellationToken);//read lấy danh sách cmt theo id cần lấy

        Task<CommentDto> GetCommentAsync(Guid id, CancellationToken cancellationToken);// get 1 comment

        Task<CommentDto> AddCommentAsync(CommentRequest request, CancellationToken cancellationToken);// thêm 1 cmt

        Task<CommentDto> EditCommentAsync(EditComment request, CancellationToken cancellationToken);// update 1 cmt

        Task<bool> RemoveCommentAsync(Guid Id, CancellationToken cancellationToken);// x
    }
}