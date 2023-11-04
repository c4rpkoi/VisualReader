namespace VisualReader
{
    public class BlockRepository : GenericRepository<Block, Guid>, IBlockRepository
    {
        private readonly VisualReaderDbContext _context;

        public BlockRepository(VisualReaderDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Block> AsQueryable()
        {
            return base.AsQueryable();
        }

        protected override void Update(Block requestObject, Block targetObject)
        {
            throw new NotImplementedException();
        }
    }
}