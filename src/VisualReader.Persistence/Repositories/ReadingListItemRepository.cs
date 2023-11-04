namespace VisualReader
{
    public class ReadingListItemRepository : GenericRepository<ReadingListItem, Guid>, IReadingListItemRepository
    {
        private readonly VisualReaderDbContext _context;

        public ReadingListItemRepository(VisualReaderDbContext context) : base(context)
        {
            _context = context;
        }

        protected override void Update(ReadingListItem requestObject, ReadingListItem targetObject)
        {
            throw new NotImplementedException();
        }
    }
}