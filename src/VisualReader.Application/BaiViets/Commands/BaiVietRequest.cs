using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Application.BaiViets.Commands.Models;
using VisualReader.Domain.Entities;

namespace VisualReader.Application.BaiViets.Commands
{
    public class BaiVietRequest : IRequest<BaiVietDto>
    {
        public Guid Id { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public DateTime ThoiGianDang { get; set; }
        public string Anh { get; set; }
        public Comment? Comment { get; set; }
        public User? User { get; set; }
        private static Func<BaiVietRequest, BaiViet> Converter = Projection.Compile();

        public static Expression<Func<BaiVietRequest, BaiViet>> Projection
        {
            get
            {
                return entity => new BaiViet
                {
                    Id = entity.Id,
                    TieuDe = entity.TieuDe,
                    MoTa = entity.MoTa,
                    ThoiGianDang = entity.ThoiGianDang,
                    Anh = entity.Anh,
                    Comment = entity.Comment,
                    User = entity.User

                };

            }
        }
        public static BaiViet Create(BaiVietRequest model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}
