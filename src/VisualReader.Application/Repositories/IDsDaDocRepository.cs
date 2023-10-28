using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Domain.Entities;

namespace VisualReader.Application.Repositories
{
    public interface IDsDaDocRepository : IRepository<DsDaDoc, Guid>
    {
        IQueryable<DsDaDoc> AsQueryable();
        public bool AddBlock(DsDaDoc dsDaDoc);
        public bool DeleteBlock(Guid id);

    }
}
