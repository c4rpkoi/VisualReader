namespace VisualReader
{
    public class FavoriteListRepository : GenericRepository<FavoriteList, Guid>, IFavoriteListRepository
    {
        private readonly VisualReaderDbContext _context;

        public FavoriteListRepository(VisualReaderDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<FavoriteList> AsQueryable()
        {
            return base.AsQueryable();
        }

        protected override void Update(FavoriteList requestObject, FavoriteList targetObject)
        {
            throw new NotImplementedException();
        }
    }
}