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
    public class DsDaDocRepository : GenericRepository<DsDaDoc, Guid>, IDsDaDocRepository
    {
        private readonly VisualReaderDbContext _context;

        public DsDaDocRepository(DbContext context) : base(context)
        {
            _context = (VisualReaderDbContext?)context;
        }

        public bool AddBlock(DsDaDoc dsDaDoc)
        {
            try
            {
                _context.DsDaDocs.Add(dsDaDoc);
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
                var dsdadoc = _context.DsDaDocs.FirstOrDefault(x => x.Id == id);
                _context.DsDaDocs.Remove(dsdadoc);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected override void Update(DsDaDoc requestObject, DsDaDoc targetObject)
        {
            targetObject.Chapter = requestObject.Chapter;//chỉ thêm trường cần update
        }
    }
}
