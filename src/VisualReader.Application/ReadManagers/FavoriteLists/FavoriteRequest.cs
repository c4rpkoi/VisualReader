using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{
    public class FavoriteRequest : IRequest<FavoriteListDto>
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdTruyen { get; set; }
        public DateTime CreateUCT { get; set; }
        public DateTime UpdateUCT { get; set; }
        public User Users { get; set; }
        public Truyen Truyens { get; set; }
        private static Func<FavoriteList, FavoriteListDto> Converter = Projection.Compile();

        public static Expression<Func<FavoriteList, FavoriteListDto>> Projection
        {
            get
            {
                return entity => new FavoriteListDto
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

        public static FavoriteListDto Create(FavoriteList model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }

    }
}
