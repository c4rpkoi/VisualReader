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
    public class FavoriteListRepository : GenericRepository<FavoriteList, Guid>, IFavoriteListRepository
    {
        private readonly VisualReaderDbContext _context;

        public FavoriteListRepository(DbContext context) : base(context)
        {
            _context = (VisualReaderDbContext?)context;
        }
        public IQueryable<FavoriteList> AsQueryable()
        {
            return base.AsQueryable();
        }

        protected override void Update(FavoriteList requestObject, FavoriteList targetObject)
        {
            throw new NotImplementedException();
        }
    }
}
