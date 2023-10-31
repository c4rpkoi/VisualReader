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
    public class DsDangDocRepository : GenericRepository<DsDangDoc, Guid>, IDsDangDocRepository
    {
        private readonly VisualReaderDbContext _context;

        public DsDangDocRepository(DbContext context) : base(context)
        {
            _context = (VisualReaderDbContext?)context;
        }
        public IQueryable<DsDangDoc> AsQueryable()
        {
            return base.AsQueryable();
        }

        public bool AddBlock(DsDangDoc dsDangDoc)
        {
            try
            {
                _context.DsDangDocs.Add(dsDangDoc);
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
                var dsdangdocs = _context.DsDangDocs.FirstOrDefault(x => x.Id == id);
                _context.DsDangDocs.Remove(dsdangdocs);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected override void Update(DsDangDoc requestObject, DsDangDoc targetObject)
        {
            targetObject.Summary = requestObject.Summary;//chỉ thêm trường cần update

        }
    }
}
