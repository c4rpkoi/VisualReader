using MediatR;
using System.Linq.Expressions;

namespace VisualReader
{
    public class EditTacGiaTruyen : IRequest<TacGiaDto>
    {
        public Guid Id { get; set; }
        public Guid TacGiaID { get; set; }
        public Guid TruyenID { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public Truyen Truyen { get; }
        public TacGia TacGia { get; }
        private static Func<EditTacGiaTruyen, TacGiaTruyen> Converter = Projection.Compile();

        public static Expression<Func<EditTacGiaTruyen, TacGiaTruyen>> Projection
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

        public static TacGiaTruyen Edit(EditTacGiaTruyen model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}