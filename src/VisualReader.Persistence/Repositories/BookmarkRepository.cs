namespace VisualReader
{
    public class BookmarkRepository : GenericRepository<Bookmark, Guid>, IBookmarkRepository
    {
        private readonly VisualReaderDbContext _context;

        public BookmarkRepository(VisualReaderDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Bookmark> AsQueryable()
        {
            return base.AsQueryable();
        }

        protected override void Update(Bookmark requestObject, Bookmark targetObject)
        {
            throw new NotImplementedException();
        }
    }
}