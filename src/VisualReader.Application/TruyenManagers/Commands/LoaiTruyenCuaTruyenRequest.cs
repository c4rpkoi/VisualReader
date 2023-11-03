using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Application.Comments.Commands.Models;
using VisualReader.Application.TruyenManagers.Models;
using VisualReader.Domain.Entities;

namespace VisualReader.Application.TruyenManagers.Commands
{
    public class LoaiTruyenCuaTruyenRequest: IRequest<LoaiTruyenCuaTruyenDto>
    {
        public Guid Id { get; set; }
        public Guid LoaiTruyenID { get; set; }
        public Guid TruyenID { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public LoaiTruyen LoaiTruyen { get; }
        public Truyen Truyen { get; }
        public IEnumerable<Chapter> Chapters { get; }
        private static Func<LoaiTruyenCuaTruyenRequest, LoaiTruyenCuaTruyen> Converter = Projection.Compile();

        public static Expression<Func<LoaiTruyenCuaTruyenRequest, LoaiTruyenCuaTruyen>> Projection
        {
            get
            {
                return entity => new LoaiTruyenCuaTruyen
                {
                    Id = entity.Id,
                    LoaiTruyenID = entity.LoaiTruyenID,
                    TruyenID = entity.TruyenID,
                    CreatedUtc = entity.CreatedUtc,
                    UpdatedUtc = entity.UpdatedUtc,
                };
            }
        }

        public static LoaiTruyenCuaTruyen Create(LoaiTruyenCuaTruyenRequest model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}
