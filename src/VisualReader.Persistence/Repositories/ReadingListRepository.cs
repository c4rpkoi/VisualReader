namespace VisualReader
{
    public class ReadingListRepository : GenericRepository<ReadingList, Guid>, IReadingListRepository
    {
        private readonly VisualReaderDbContext _context;

        public ReadingListRepository(VisualReaderDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ReadingList> AsQueryable()
        {
            return base.AsQueryable();
        }

        protected override void Update(ReadingList requestObject, ReadingList targetObject)
        {
            throw new NotImplementedException();
        }
    }
}