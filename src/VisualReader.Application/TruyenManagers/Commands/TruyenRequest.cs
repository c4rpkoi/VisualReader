using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Application.Comments.Commands.Models;
using VisualReader.Application.TruyenManagers.Commands.Models;
using VisualReader.Domain.Entities;

namespace VisualReader.Application.TruyenManagers.Commands
{
    public class TruyenRequest : IRequest<TruyenDto>
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string TenTruyen { get; set; }
        public byte[] AnhBia { get; set; }
        public int AgeRatting { get; set; }
        public int TinhTrang { get; set; }
        public int LuotXem { get; set; }
        public int LuotDanhGia { get; set; }
        public int SoLuongTheoDoi { get; set; }
        public float XepHang { get; set; }
        public string NoiDung { get; set; }
        public int TrangThai { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }

        public IEnumerable<LoaiTruyenCuaTruyen> LoaiTruyenCuaTruyens { get; }
        public IEnumerable<TheLoaiTruyen> TheLoaiTruyens { get; }
        public IEnumerable<TacGiaTruyen> TacGiaTruyens { get; }
        private static Func<TruyenRequest, Truyen> Converter = Projection.Compile();

        public static Expression<Func<TruyenRequest, Truyen>> Projection
        {
            get
            {
                return entity => new Truyen
                {
                    Id = entity.Id,
                    Ma = entity.Ma,
                    TenTruyen = entity.TenTruyen,
                    AnhBia = entity.AnhBia,
                    AgeRatting = entity.AgeRatting,
                    TinhTrang = entity.TinhTrang,
                    LuotXem = entity.LuotXem,
                    LuotDanhGia = entity.LuotDanhGia,
                    SoLuongTheoDoi = entity.SoLuongTheoDoi,
                    XepHang = entity.XepHang,
                    NoiDung = entity.NoiDung,
                    TrangThai = entity.TrangThai,
                    CreatedUtc = entity.CreatedUtc,
                    UpdatedUtc = entity.UpdatedUtc,
                };
            }
        }

        public static Truyen Create(TruyenRequest model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}
