using MediatR;

namespace VisualReader
{
    public class GetCommentByParentId : SearchRequest, IRequest<SearchResponse<CommentDto>>
    {
        //cái này dùng để tìm kiếm và phân trang
        public GetCommentByParentId(int pageIndex, int pageSize, string filter)
        {
            PageIndex = pageIndex;// đây là số trang chọn này
            PageSize = pageSize;//đây là số phần tử 1 trang này
            Filter = filter;//đây là điều kiện lọc này
        }
    }
}