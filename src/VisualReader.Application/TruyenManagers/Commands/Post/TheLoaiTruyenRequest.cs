using MediatR;
using System.Linq.Expressions;

namespace VisualReader
{
    public class TheLoaiTruyenRequest : IRequest<TheLoaiTruyenDto>
    {
        public Guid Id { get; set; }
        public Guid TruyenID { get; set; }
        public Guid TheLoaiID { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public Truyen Truyen { get; }
        public TheLoai TheLoai { get; }
        private static Func<TheLoaiTruyenRequest, TheLoaiTruyen> Converter = Projection.Compile();

        public static Expression<Func<TheLoaiTruyenRequest, TheLoaiTruyen>> Projection
        {
            get
            {
                return entity => new TheLoaiTruyen
                {
                    Id = entity.Id,
                    TruyenID = entity.TruyenID,
                    TheLoaiID = entity.TheLoaiID,
                    CreatedUtc = entity.CreatedUtc,
                    UpdatedUtc = entity.UpdatedUtc,
                };
            }
        }

        public static TheLoaiTruyen Create(TheLoaiTruyenRequest model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}