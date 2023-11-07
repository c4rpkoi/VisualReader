using MediatR;
using System.Linq.Expressions;

namespace VisualReader
{
    public class EditLoaiTruyenCuaTruyen : IRequest<LoaiTruyenCuaTruyenDto>
    {
        public Guid Id { get; set; }
        public Guid LoaiTruyenID { get; set; }
        public Guid TruyenID { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public LoaiTruyen LoaiTruyen { get; }
        public Truyen Truyen { get; }
        public IEnumerable<Chapter> Chapters { get; }
        private static Func<EditLoaiTruyenCuaTruyen, LoaiTruyenCuaTruyen> Converter = Projection.Compile();

        public static Expression<Func<EditLoaiTruyenCuaTruyen, LoaiTruyenCuaTruyen>> Projection
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

        public static LoaiTruyenCuaTruyen Edit(EditLoaiTruyenCuaTruyen model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}