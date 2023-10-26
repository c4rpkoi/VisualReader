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

        public BookmarkRepository(DbContext context) : base(context)
        {
            _context = (VisualReaderDbContext?)context;
        }

        public IQueryable<Bookmark> AsQueryable()
        {
            return base.AsQueryable();
        }

        public bool AddBookmark(Bookmark bookmark)
        {
            try
            {
                _context.Bookmarks.Add(bookmark);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBookmark(Guid id)
        {
            try
            {
                var bookmarks = _context.Bookmarks.FirstOrDefault(x => x.Id == id);
                _context.Bookmarks.Remove(bookmarks);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected override void Update(Bookmark requestObject, Bookmark targetObject)
        {
            throw new NotImplementedException();
        }
    }
}
