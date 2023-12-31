﻿namespace VisualReader
{
    public class TacGiaTruyenRepository : GenericRepository<TacGiaTruyen, Guid>, ITacGiaTruyenRepository
    {
        private readonly VisualReaderDbContext _context;

        public TacGiaTruyenRepository(VisualReaderDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<TacGiaTruyen> AsQueryable()
        {
            return base.AsQueryable();
        }

        protected override void Update(TacGiaTruyen requestObject, TacGiaTruyen targetObject)
        {
            targetObject.TacGiaID = requestObject.TacGiaID;
            targetObject.TruyenID = requestObject.TruyenID;
            targetObject.UpdatedUtc = requestObject.UpdatedUtc;
        }
    }
}