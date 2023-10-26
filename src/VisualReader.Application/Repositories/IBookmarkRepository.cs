﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Domain.Entities;

namespace VisualReader.Application.Repositories
{
    public interface IBookmarkRepository : IRepository<Bookmark, Guid>
    {
        IQueryable<Bookmark> AsQueryable();
        public bool AddBookmark(Bookmark bookmark);
        public bool DeleteBookmark(Guid id);
    }
}
