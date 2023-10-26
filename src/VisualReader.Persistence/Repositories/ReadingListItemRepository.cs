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
    public class ReadingListItemRepository : GenericRepository<ReadingLsistItem, Guid>, IReadingListItemRepository
    {
        private readonly VisualReaderDbContext _context;

        public ReadingListItemRepository(DbContext context) : base(context)
        {
            _context = (VisualReaderDbContext?)context;
        }

        protected override void Update(ReadingLsistItem requestObject, ReadingLsistItem targetObject)
        {
            throw new NotImplementedException();
        }
    }
}
