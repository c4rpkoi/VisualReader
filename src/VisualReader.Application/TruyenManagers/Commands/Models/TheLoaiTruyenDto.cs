using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Domain.Entities;

namespace VisualReader.Application.TruyenManagers.Commands.Models
{
    public class TheLoaiTruyenDto
    {
        public Guid Id { get; set; }
        public Guid TruyenID { get; set; }
        public Guid TheLoaiID { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public Truyen Truyen { get; }
        public TheLoai TheLoai { get; }
        private static Func<TheLoaiTruyen, TheLoaiTruyenDto> Converter = Projection.Compile();

        public static Expression<Func<TheLoaiTruyen, TheLoaiTruyenDto>> Projection
        {
            get
            {
                return entity => new TheLoaiTruyenDto
                {
                    Id = entity.Id,
                    TruyenID = entity.TruyenID,
                    TheLoaiID = entity.TheLoaiID,
                    CreatedUtc = entity.CreatedUtc,
                    UpdatedUtc = entity.UpdatedUtc,
                };
            }
        }

        public static TheLoaiTruyenDto Create(TheLoaiTruyen model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}
