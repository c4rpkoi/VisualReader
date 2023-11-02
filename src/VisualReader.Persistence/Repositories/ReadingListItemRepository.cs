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
    public class ReadingListItemRepository : GenericRepository<ReadingListItem, Guid>, IReadingListItemRepository
    {
        private readonly VisualReaderDbContext _context;

        public ReadingListItemRepository(VisualReaderDbContext context) : base(context)
        {
            _context = context;
        }

        protected override void Update(ReadingListItem requestObject, ReadingListItem targetObject)
        {
            throw new NotImplementedException();
        }
    }
}
