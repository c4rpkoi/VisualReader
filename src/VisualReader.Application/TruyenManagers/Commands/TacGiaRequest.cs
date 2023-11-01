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
    public class TacGiaRequest : IRequest<TacGiaDto>
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string TenTacGia { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public IEnumerable<TacGiaTruyen> TacGiaTruyens { get; }
        private static Func<TacGiaRequest, TacGia> Converter = Projection.Compile();

        public static Expression<Func<TacGiaRequest, TacGia>> Projection
        {
            get
            {
                return entity => new TacGia
                {
                    Id = entity.Id,
                    Ma = entity.Ma,
                    TenTacGia = entity.TenTacGia,
                    CreatedUtc = entity.CreatedUtc,
                    UpdatedUtc = entity.UpdatedUtc,
                };
            }
        }

        public static TacGia Create(TacGiaRequest model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}
