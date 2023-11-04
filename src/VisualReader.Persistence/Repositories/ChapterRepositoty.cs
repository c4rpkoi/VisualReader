namespace VisualReader
{
    public class ChapterRepositoty : GenericRepository<Chapter, Guid>, IChapterRepository
    {
        private readonly VisualReaderDbContext _context;

        public ChapterRepositoty(VisualReaderDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Chapter> AsQueryable()
        {
            return base.AsQueryable();
        }

        protected override void Update(Chapter requestObject, Chapter targetObject)
        {
            targetObject.TruyenID = requestObject.TruyenID;
            targetObject.UserID = requestObject.UserID;
            targetObject.LoaiTruyenCuaTruyenID = requestObject.LoaiTruyenCuaTruyenID;
            targetObject.Title = requestObject.Title;
            targetObject.Ma = requestObject.Ma;
            targetObject.NgayDang = requestObject.NgayDang;
            targetObject.LuotXem = requestObject.LuotXem;
            targetObject.UpdatedUtc = requestObject.UpdatedUtc;
        }
    }
}