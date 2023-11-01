using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Domain.Entities;

namespace VisualReader.Application.TruyenManagers.Commands.Models
{
    public class LoaiTruyenDto
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string TenTheLoai { get; set; }
        public string Mota { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public IEnumerable<LoaiTruyenCuaTruyen> LoaiTruyenCuaTruyens { get; }
        private static Func<LoaiTruyen, LoaiTruyenDto> Converter = Projection.Compile();

        public static Expression<Func<LoaiTruyen, LoaiTruyenDto>> Projection
        {
            get
            {
                return entity => new LoaiTruyenDto
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

        public static LoaiTruyenDto Create(LoaiTruyen model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}
