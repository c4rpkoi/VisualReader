namespace VisualReader
{
    public class LoaiTruyenCuaTruyenRepository : GenericRepository<LoaiTruyenCuaTruyen, Guid>, ILoaiTruyenCuaTruyenRepository
    {
        private readonly VisualReaderDbContext _context;

        public LoaiTruyenCuaTruyenRepository(VisualReaderDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<LoaiTruyenCuaTruyen> AsQueryable()
        {
            return base.AsQueryable();
        }

        protected override void Update(LoaiTruyenCuaTruyen requestObject, LoaiTruyenCuaTruyen targetObject)
        {
            targetObject.LoaiTruyenID = requestObject.LoaiTruyenID;
            targetObject.TruyenID = requestObject.TruyenID;
            targetObject.UpdatedUtc = requestObject.UpdatedUtc;
        }
    }
}