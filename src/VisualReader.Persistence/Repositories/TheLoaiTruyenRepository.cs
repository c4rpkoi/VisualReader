namespace VisualReader
{
    public class TheLoaiTruyenRepository : GenericRepository<TheLoaiTruyen, Guid>, ITheLoaiTruyenRepository
    {
        private readonly VisualReaderDbContext _context;

        public TheLoaiTruyenRepository(VisualReaderDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<TheLoaiTruyen> AsQueryable()
        {
            return base.AsQueryable();
        }

        protected override void Update(TheLoaiTruyen requestObject, TheLoaiTruyen targetObject)
        {
            targetObject.TruyenID = requestObject.TruyenID;
            targetObject.TheLoaiID = requestObject.TheLoaiID;
            targetObject.UpdatedUtc = requestObject.UpdatedUtc;
        }
    }
}