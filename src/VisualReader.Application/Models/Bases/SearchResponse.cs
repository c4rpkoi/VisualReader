namespace VisualReader.Application.Models.Bases
{
    public class SearchResponse<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage => (TotalCount / PageSize) + ((TotalCount % PageSize) > 0 ? 1 : 0);
        public IEnumerable<T> Data { get; set; }

        public SearchResponse(int pageIndex, int pageSize, int totalCount, IEnumerable<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            Data = data;
        }
    }

    public class Filter
    {
        public string Field { get; set; }
        public string Condition { get; set; }
        public string DataType { get; set; }
        public object Value { get; set; }
    }
}