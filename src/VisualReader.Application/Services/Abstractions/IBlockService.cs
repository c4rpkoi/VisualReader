namespace VisualReader
{
    public interface IBlockService
    {
       // Task<SearchResponse<CommentDto>> GetAllCommentAsync(GetCommentByParentId request, CancellationToken cancellationToken);//read lấy danh sách cmt theo id cần lấy

     //   Task<CommentDto> GetCommentAsync(Guid id, CancellationToken cancellationToken);// get 1 comment

        Task<BlockDto> AddBlockAsync(BlockRequest request, CancellationToken cancellationToken);// thêm 1 cmt

    //    Task<CommentDto> EditCommentAsync(EditComment request, CancellationToken cancellationToken);// update 1 cmt

        Task<bool> RemoveBlockAsync(Guid Id, CancellationToken cancellationToken);// x

    }
}
