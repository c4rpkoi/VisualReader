using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{
    public class BlockRequest
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdTruyen { get; set; }
        public DateTime CreateUCT { get; set; }
        public DateTime UpdateUCT { get; set; }
        public User Users { get; set; }
        public Truyen Truyens { get; set; }
        private static Func<Block, BlockDto> Converter = Projection.Compile();

        public static Expression<Func<Block, BlockDto>> Projection
        {
            get
            {
                return entity => new BlockDto
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

        public static BlockDto Create(Block model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}
