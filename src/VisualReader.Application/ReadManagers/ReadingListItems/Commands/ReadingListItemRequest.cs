using MediatR;
using System.Linq.Expressions;

namespace VisualReader
{
    public class ReadingListItemRequest : IRequest<ReadingListItemDto>
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdTruyen { get; set; }
        public Guid IdDsDangDoc { get; set; }
        public Guid IdChapter { get; set; }
        public string PageIndex { get; set; }
        public DateTime CreateUCT { get; set; }
        public DateTime UpdateUCT { get; set; }
        public ReadingList ReadingLists { get; set; }
        public Truyen Truyens { get; set; }
        private static Func<ReadingListItemRequest, ReadingListItem> Converter = Projection.Compile();

        public static Expression<Func<ReadingListItemRequest, ReadingListItem>> Projection
        {
            get
            {
                return entity => new ReadingListItem
                {
                    Id = entity.Id,
                    IdUser = entity.IdUser,
                    Truyens = entity.Truyens,
                    CreateUCT = entity.CreateUCT,
                    UpdateUCT = entity.UpdateUCT,
                    IdTruyen = entity.IdTruyen,
                    IdChapter = entity.IdChapter,
                    IdDsDangDoc = entity.IdDsDangDoc,
                    PageIndex = entity.PageIndex,
                    ReadingLists = entity.ReadingLists,
                };
            }
        }

        public static ReadingListItem Create(ReadingListItemRequest model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }

    }
}
