using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader
{
    public class RemoveBaiViet : IRequest<bool>
    {
        public Guid Id { get; set; }
        public RemoveBaiViet(Guid id) => Id = id;
    }
}
