using MediatR;
using System.Linq.Expressions;

namespace VisualReader
{
    public class FavoriteListRequest : IRequest<FavoriteListDto>
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdTruyen { get; set; }
        public DateTime CreateUCT { get; set; }
        public DateTime UpdateUCT { get; set; }
        public User Users { get; set; }
        public Truyen Truyens { get; set; }
        private static Func<FavoriteListRequest, FavoriteList> Converter = Projection.Compile();

        public static Expression<Func<FavoriteListRequest, FavoriteList>> Projection
        {
            get
            {
                return entity => new FavoriteList
                {
                    Id = entity.Id,
                    CreateUCT = entity.CreateUCT,
                    IdUser = entity.IdUser,
                    UpdateUCT = entity.UpdateUCT,
                    IdTruyen = entity.IdTruyen,
                    Users = entity.Users,
                    Truyens = entity.Truyens,
                };
            }
        }

        public static FavoriteList Create(FavoriteListRequest model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }

    }
}
