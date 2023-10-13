using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Domain.Entities;

namespace VisualReader.Application.Repositories
{
    public interface ICommentRepository : IRepository<Comment, Guid>
    {
        IQueryable<Comment> AsQueryable(); //phải có phương thức này để get all
    }
}
