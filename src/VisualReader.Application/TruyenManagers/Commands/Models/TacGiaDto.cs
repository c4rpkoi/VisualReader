using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Domain.Entities;

namespace VisualReader.Application.TruyenManagers.Commands.Models
{
    public class TacGiaDto
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string TenTacGia { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public IEnumerable<TacGiaTruyen> TacGiaTruyens { get; }
        private static Func<TacGia, TacGiaDto> Converter = Projection.Compile();

        public static Expression<Func<TacGia, TacGiaDto>> Projection
        {
            get
            {
                return entity => new TacGiaDto
                {
                    Id = entity.Id,
                    Ma = entity.Ma,
                    TenTacGia = entity.TenTacGia,
                    CreatedUtc = entity.CreatedUtc,
                    UpdatedUtc = entity.UpdatedUtc,
                };
            }
        }

        public static TacGiaDto Create(TacGia model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}
