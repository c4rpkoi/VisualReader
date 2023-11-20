using MediatR;
using System.Linq.Expressions;

namespace VisualReader
{
    public class EditTacGia : IRequest<TacGiaDto>
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string TenTacGia { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public IEnumerable<TacGiaTruyen> TacGiaTruyens { get; }
        private static Func<EditTacGia, TacGia> Converter = Projection.Compile();

        public static Expression<Func<EditTacGia, TacGia>> Projection
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

        public static TacGia Edit(EditTacGia model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}