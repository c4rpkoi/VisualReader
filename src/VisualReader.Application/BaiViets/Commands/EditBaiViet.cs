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
    public class EditBaiViet : IRequest<BaiVietDto>
    {
        public Guid Id { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public DateTime ThoiGianDang { get; set; }
        public string Anh { get; set; }
        //public Comment? Comment { get; set; }
        //public User? User { get; set; }
        private static Func<EditBaiViet, BaiViet> Converter = Projection.Compile();

        public static Expression<Func<EditBaiViet, BaiViet>> Projection
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


                };

            }
        }
        public static BaiViet Create(EditBaiViet model)
        {
            if (model != null)
            {
                return Converter(model);
            }
            return null;
        }
    }
}
