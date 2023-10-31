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
    public class TheLoaiRepository : GenericRepository<TheLoai,Guid>,ITheLoaiRepository
    {
        private readonly VisualReaderDbContext _context;
        public TheLoaiRepository(VisualReaderDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<TheLoai> AsQueryable()
        {
            return base.AsQueryable();
        }
        protected override void Update(TheLoai requestObject, TheLoai targetObject)
        {
            targetObject.Ma = requestObject.Ma;
            targetObject.TenTheLoai = requestObject.TenTheLoai;
            targetObject.Mota = requestObject.Mota;
            targetObject.UpdatedUtc = requestObject.UpdatedUtc;
        }
    }
}
