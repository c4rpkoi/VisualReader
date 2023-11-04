using MediatR;
using System.Linq.Expressions;

namespace VisualReader
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