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
    public class BookmarkRepository : GenericRepository<Bookmark, Guid>, IBookmarkRepository
    {
        private readonly VisualReaderDbContext _context;

        public BookmarkRepository(VisualReaderDbContext context) : base(context)
        {
            _context = context;
        }
        public IQueryable<Bookmark> AsQueryable()
        {
            return base.AsQueryable();
        }
        protected override void Update(Bookmark requestObject, Bookmark targetObject)
        {
            throw new NotImplementedException();
        }
    }
}
