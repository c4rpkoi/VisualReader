using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Application.Repositories;
using VisualReader.Domain.Entities;
using VisualReader.Persistence.Context;

namespace VisualReader.Persistence.Repositories
{
    public class LoaiTruyenCuaTruyenRepository : GenericRepository<LoaiTruyenCuaTruyen,Guid>,ILoaiTruyenCuaTruyenRepository
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
