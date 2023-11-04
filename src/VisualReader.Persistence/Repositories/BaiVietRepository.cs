using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{
    public class BaiVietRepository : GenericRepository<BaiViet, Guid>, IBaiVietReposytory
    {
        private readonly VisualReaderDbContext _context;
        public BaiVietRepository(VisualReaderDbContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<BaiViet> AsQueryable()
        {
            return base.AsQueryable();
        }
        protected override void Update(BaiViet requestObject, BaiViet targetObject)
        {
            throw new NotImplementedException();
        }
    }
}
