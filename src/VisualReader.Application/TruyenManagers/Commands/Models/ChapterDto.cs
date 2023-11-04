using System.Linq.Expressions;

namespace VisualReader
{
    public class ChapterDto
    {
        public Guid Id { get; set; }
        public Guid TruyenID { get; set; }
        public string UserID { get; set; }
        public Guid LoaiTruyenCuaTruyenID { get; set; }
        public string? Title { get; set; }
        public float Ma { get; set; }
        public DateTime NgayDang { get; set; }
        public int LuotXem { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public ChapterData ChapterData { get; }
        public LoaiTruyenCuaTruyen LoaiTruyenCuaTruyen { get; }
        public IEnumerable<Chapter> Chapters { get; set; }
        private static Func<Chapter, ChapterDto> Converter = Projection.Compile();

        public static Expression<Func<Chapter, ChapterDto>> Projection
        {
            get
            {
                return entity => new ChapterDto
                {
                    Id = entity.Id,
                    TruyenID = entity.TruyenID,
                    UserID = entity.UserID,
                    LoaiTruyenCuaTruyenID = entity.LoaiTruyenCuaTruyenID,
                    Title = entity.Title,
                    Ma = entity.Ma,
                    NgayDang = entity.NgayDang,
                    LuotXem = entity.LuotXem,
                    CreatedUtc = entity.CreatedUtc,
                    UpdatedUtc = entity.UpdatedUtc,
                };
            }
        }

        public static ChapterDto Create(Chapter model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}