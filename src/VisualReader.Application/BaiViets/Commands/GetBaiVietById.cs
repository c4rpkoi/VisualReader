using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader;

namespace VisualReader
{
    public class GetBaiVietById : IRequest<BaiVietDto>
    {
        public Guid Id { get; set; }

        public GetBaiVietById(Guid id) => Id = id;
    }
}
