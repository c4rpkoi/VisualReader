using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Domain.Entities;

namespace VisualReader.Application.Repositories
{
    public interface IDsDangDocRepository : IRepository<DsDangDoc, Guid>
    {
        IQueryable<DsDangDoc> AsQueryable();
        public bool AddBlock(DsDangDoc dsDangDoc);
        public bool DeleteBlock(Guid id);

    }
}
