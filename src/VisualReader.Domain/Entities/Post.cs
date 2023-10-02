using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualReader.Domain.Entities
{
    public class Post:IEntity<Guid>
    {
        public Guid Id { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        //bảng dummy chúng m tự sửa
    }
}
