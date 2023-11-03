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
    public class LoaiTruyenRequest : IRequest<LoaiTruyenDto>
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string TenTheLoai { get; set; }
        public string Mota { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public IEnumerable<LoaiTruyenCuaTruyen> LoaiTruyenCuaTruyens { get; }
        private static Func<LoaiTruyenRequest, LoaiTruyen> Converter = Projection.Compile();

        public static Expression<Func<LoaiTruyenRequest, LoaiTruyen>> Projection
        {
            get
            {
                return entity => new LoaiTruyen
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

        public static LoaiTruyen Create(LoaiTruyenRequest model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}
