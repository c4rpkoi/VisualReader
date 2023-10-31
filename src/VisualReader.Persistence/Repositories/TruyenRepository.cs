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
    public class TruyenRepository : GenericRepository<Truyen,Guid>,ITruyenRepository
    {
        private readonly VisualReaderDbContext _context;
        public TruyenRepository(VisualReaderDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Truyen> AsQueryable()
        {
            return base.AsQueryable();
        }
        protected override void Update(Truyen requestObject, Truyen targetObject)
        {
            targetObject.Ma = requestObject.Ma;
            targetObject.TenTruyen = requestObject.TenTruyen;
            targetObject.AnhBia = requestObject.AnhBia;
            targetObject.AgeRatting = requestObject.AgeRatting;
            targetObject.TinhTrang = requestObject.TinhTrang;
            targetObject.LuotXem = requestObject.LuotXem;
            targetObject.LuotDanhGia = requestObject.LuotDanhGia;
            targetObject.SoLuongTheoDoi = requestObject.SoLuongTheoDoi;
            targetObject.XepHang = requestObject.XepHang;
            targetObject.NoiDung = requestObject.NoiDung;
            targetObject.TrangThai = requestObject.TrangThai;
            targetObject.UpdatedUtc = requestObject.UpdatedUtc;
        }
    }
}
