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

        public bool AddBlock(Block block)
        {
            try
            {
                _context.Blocks.Add(block);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBlock(Guid id)
        {
            try
            {
                var blocks = _context.Blocks.FirstOrDefault(x => x.Id == id);
                _context.Blocks.Remove(blocks);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected override void Update(Block requestObject, Block targetObject)
        {
            throw new NotImplementedException();
        }
    }
}
