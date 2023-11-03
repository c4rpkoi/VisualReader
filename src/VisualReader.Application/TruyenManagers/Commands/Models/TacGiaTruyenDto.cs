using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Domain.Entities;

namespace VisualReader.Application.TruyenManagers.Commands.Models
{
    public class TacGiaTruyenDto
    {
        public Guid Id { get; set; }
        public Guid TacGiaID { get; set; }
        public Guid TruyenID { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public Truyen Truyen { get; }
        public TacGia TacGia { get; }
        private static Func<TacGiaTruyen, TacGiaTruyenDto> Converter = Projection.Compile();

        public static Expression<Func<TacGiaTruyen, TacGiaTruyenDto>> Projection
        {
            get
            {
                return entity => new TacGiaTruyenDto
                {
                    Id = entity.Id,
                    TacGiaID = entity.TacGiaID,
                    TruyenID = entity.TruyenID,
                    CreatedUtc = entity.CreatedUtc,
                    UpdatedUtc = entity.UpdatedUtc,
                };
            }
        }

        public static TacGiaTruyenDto Create(TacGiaTruyen model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}
