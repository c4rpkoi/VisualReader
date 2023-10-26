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
    public class BlockRepository : GenericRepository<Block, Guid>, IBlockRepository
    {
        private readonly VisualReaderDbContext _context; public BlockRepository(DbContext context) : base(context)
        {
            _context = (VisualReaderDbContext?)context;
        }
        public IQueryable<Block> AsQueryable()
        {
            return base.AsQueryable();
        }
        protected override void Update(Block requestObject, Block targetObject)
        {
            throw new NotImplementedException();
        }
    }
}
