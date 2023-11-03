using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Domain.Entities;

namespace VisualReader.Application.TruyenManagers.Models
{
    public class LoaiTruyenCuaTruyenDto
    {
        public Guid Id { get; set; }
        public Guid LoaiTruyenID { get; set; }
        public Guid TruyenID { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public LoaiTruyen LoaiTruyen { get; }
        public Truyen Truyen { get; }
        public IEnumerable<Chapter> Chapters { get; }
        private static Func<LoaiTruyenCuaTruyen, LoaiTruyenCuaTruyenDto> Converter = Projection.Compile();

        public static Expression<Func<LoaiTruyenCuaTruyen, LoaiTruyenCuaTruyenDto>> Projection
        {
            get
            {
                return entity => new LoaiTruyenCuaTruyenDto
                {
                    Id = entity.Id,
                    LoaiTruyenID = entity.LoaiTruyenID,
                    TruyenID = entity.TruyenID,
                    CreatedUtc = entity.CreatedUtc,
                    UpdatedUtc = entity.UpdatedUtc,
                };
            }
        }

        public static LoaiTruyenCuaTruyenDto Create(LoaiTruyenCuaTruyen model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}
