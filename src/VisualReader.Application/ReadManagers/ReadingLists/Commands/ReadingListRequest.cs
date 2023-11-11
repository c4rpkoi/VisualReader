using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{
    public class ReadingListRequest : IRequest<ReadingListDto>
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public DateTime CreateUCT { get; set; }
        public DateTime UpdateUCT { get; set; }
        public User Users { get; set; }
        public IEnumerable<ReadingListItem> readingListItems { get; set; }
        private static Func<ReadingListRequest, ReadingList> Converter = Projection.Compile();

        public static Expression<Func<ReadingListRequest, ReadingList>> Projection
        {
            get
            {
                return entity => new ReadingList
                {
                    Id = entity.Id,
                    IdUser = entity.IdUser,
                    UpdateUCT = entity.UpdateUCT,
                    Users = entity.Users,
                    CreateUCT = entity.CreateUCT,
                    readingListItems = entity.readingListItems
                };
            }
        }

        public static ReadingList Create(ReadingListRequest model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }

    }
}
