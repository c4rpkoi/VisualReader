using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{
    public interface IBaiVietReposytory : IRepository<BaiViet, Guid>
    {
        IQueryable<BaiViet> AsQueryable();
    }
}
