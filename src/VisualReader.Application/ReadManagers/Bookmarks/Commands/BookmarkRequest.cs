using MediatR;
using System.Linq.Expressions;

namespace VisualReader
{
    public class BookmarkRequest : IRequest<BookmarkDto>
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdChapter { get; set; }
        public string PageIndex { get; set; }
        public DateTime CreateUCT { get; set; }
        public DateTime UpdateUCT { get; set; }
        public Chapter Chapters { get; set; }
        public User Users { get; set; }
        private static Func<BookmarkRequest, Bookmark> Converter = Projection.Compile();

        public static Expression<Func<BookmarkRequest, Bookmark>> Projection
        {
            get
            {
                return entity => new Bookmark
                {
                    Id = entity.Id,
                    Users = entity.Users,
                    UpdateUCT = entity.UpdateUCT,
                    IdUser = entity.IdUser,
                    CreateUCT = entity.CreateUCT,
                    Chapters = entity.Chapters,
                    IdChapter = entity.IdChapter,
                    PageIndex = entity.PageIndex
                };
            }
        }

        public static Bookmark Create(BookmarkRequest model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}
