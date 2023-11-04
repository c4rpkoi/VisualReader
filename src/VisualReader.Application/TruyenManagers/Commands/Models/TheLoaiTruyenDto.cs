using System.Linq.Expressions;

namespace VisualReader
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