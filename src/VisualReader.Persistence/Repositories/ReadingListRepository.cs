using Microsoft.EntityFrameworkCore;
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
    public class ReadingListRepository : GenericRepository<ReadingList, Guid>, IReadingListRepository
    {
        private readonly VisualReaderDbContext _context;

        public ReadingListRepository(VisualReaderDbContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<ReadingList> AsQueryable()
        {
            return base.AsQueryable();
        }

        protected override void Update(ReadingList requestObject, ReadingList targetObject)
        {
            throw new NotImplementedException();
        }
    }
}
