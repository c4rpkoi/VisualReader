namespace VisualReader
{
    public class SearchRequest
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 20;
        public string Filter { get; set; }

        public SearchRequest(int pageIndex = 1, int pageSize = 20, string filter = "")
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Filter = filter;
        }
    }
}