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
    public class TacGiaRepository : GenericRepository<TacGia, Guid>,ITacGiaRepository
    {
        private readonly VisualReaderDbContext _context;
        public TacGiaRepository(VisualReaderDbContext context):base(context) 
        {
            _context = context;
        }
        public IQueryable<TacGia> AsQueryable()
        {
            return base.AsQueryable();
        }
        protected override void Update(TacGia requestObject, TacGia targetObject)
        {
            targetObject.Ma = requestObject.Ma;
            targetObject.TenTacGia = requestObject.TenTacGia;
            targetObject.UpdatedUtc = requestObject.UpdatedUtc;
            targetObject.UpdatedUtc = DateTime.UtcNow;
        }
    }
}
