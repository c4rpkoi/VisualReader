using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{
    public class BlockRequest : IRequest<BlockDto>
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdTruyen { get; set; }
        public DateTime CreateUCT { get; set; }
        public DateTime UpdateUCT { get; set; }
        public User Users { get; set; }
        public Truyen Truyens { get; set; }
        private static Func<BlockRequest, Block> Converter = Projection.Compile();

        public static Expression<Func<BlockRequest, Block>> Projection
        {
            get
            {
                return entity => new Block
                {
                    Id = entity.Id,
                    CreateUCT = entity.CreateUCT,
                    IdTruyen = entity.IdTruyen,
                    IdUser = entity.IdUser,
                    Truyens = entity.Truyens,
                    UpdateUCT = entity.UpdateUCT,
                    Users = entity.Users
                };
            }
        }

        public static Block Create(BlockRequest model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}
