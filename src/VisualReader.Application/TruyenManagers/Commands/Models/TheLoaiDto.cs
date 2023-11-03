using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Domain.Entities;

namespace VisualReader.Application.TruyenManagers.Commands.Models
{
    public class TheLoaiDto
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string TenTheLoai { get; set; }
        public string Mota { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public IEnumerable<TheLoaiTruyen> TheLoaiTruyens { get; }
        private static Func<TheLoai, TheLoaiDto> Converter = Projection.Compile();

        public static Expression<Func<TheLoai, TheLoaiDto>> Projection
        {
            get
            {
                return entity => new TheLoaiDto
                {
                    Id = entity.Id,
                    Ma = entity.Ma,
                    TenTheLoai = entity.TenTheLoai,
                    Mota = entity.Mota,
                    CreatedUtc = entity.CreatedUtc,
                    UpdatedUtc = entity.UpdatedUtc,
                };
            }
        }

        public static TheLoaiDto Create(TheLoai model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}
