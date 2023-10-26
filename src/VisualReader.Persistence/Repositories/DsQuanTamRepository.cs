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
    public class DsQuanTamRepository : GenericRepository<DsQuanTam, Guid>, IDsQuanTamRepository
    {
        private readonly VisualReaderDbContext _context;

        public DsQuanTamRepository(DbContext context) : base(context)
        {
            _context = (VisualReaderDbContext?)context;
        }
        public IQueryable<DsQuanTam> AsQueryable()
        {
            return base.AsQueryable();
        }

        public bool AddDsQuanTam(DsQuanTam  dsQuanTam)
        {
            try
            {
                _context.DsQuanTams.Add(dsQuanTam);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteDsQuanTam(Guid id)
        {
            try
            {
                var dsquantams = _context.DsQuanTams.FirstOrDefault(x => x.Id == id);
                _context.DsQuanTams.Remove(dsquantams);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected override void Update(DsQuanTam requestObject, DsQuanTam targetObject)
        {
            targetObject.LoaiQuanTam = requestObject.LoaiQuanTam;//chỉ thêm trường cần update
        }
    }
}
