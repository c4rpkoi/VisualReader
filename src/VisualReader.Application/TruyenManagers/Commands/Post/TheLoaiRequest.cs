using MediatR;
using System.Linq.Expressions;

namespace VisualReader
{
    public class TheLoaiRequest : IRequest<TheLoaiDto>
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string TenTheLoai { get; set; }
        public string Mota { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public IEnumerable<TheLoaiTruyen> TheLoaiTruyens { get; }
        private static Func<TheLoaiRequest, TheLoai> Converter = Projection.Compile();

        public static Expression<Func<TheLoaiRequest, TheLoai>> Projection
        {
            get
            {
                return entity => new TheLoai
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

        public static TheLoai Create(TheLoaiRequest model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}