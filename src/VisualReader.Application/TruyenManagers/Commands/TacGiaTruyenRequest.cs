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
    public class TacGiaTruyenRequest : IRequest<TacGiaDto>
    {
        public Guid Id { get; set; }
        public Guid TacGiaID { get; set; }
        public Guid TruyenID { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public Truyen Truyen { get; }
        public TacGia TacGia { get; }
        private static Func<TacGiaTruyenRequest, TacGiaTruyen> Converter = Projection.Compile();

        public static Expression<Func<TacGiaTruyenRequest, TacGiaTruyen>> Projection
        {
            get
            {
                return entity => new TacGiaTruyen
                {
                    Id = entity.Id,
                    TacGiaID = entity.TacGiaID,
                    TruyenID = entity.TruyenID,
                    CreatedUtc = entity.CreatedUtc,
                    UpdatedUtc = entity.UpdatedUtc,
                };
            }
        }

        public static TacGiaTruyen Create(TacGiaTruyenRequest model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}
