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
    public class LoaiTruyenRepository : GenericRepository<LoaiTruyen,Guid>,ILoaiTruyenRepository
    {
        private readonly VisualReaderDbContext _context;
        public LoaiTruyenRepository(VisualReaderDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<LoaiTruyen> AsQueryable()
        {
            return base.AsQueryable();
        }
        protected override void Update(LoaiTruyen requestObject, LoaiTruyen targetObject)
        {
            targetObject.Ma = requestObject.Ma;
            targetObject.TenTheLoai = requestObject.TenTheLoai;
            targetObject.Mota = requestObject.Mota;
            targetObject.UpdatedUtc = requestObject.UpdatedUtc;
        }
    }
}
