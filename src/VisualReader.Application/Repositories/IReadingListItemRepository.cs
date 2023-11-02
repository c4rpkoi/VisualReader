using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualReader.Domain.Entities;

namespace VisualReader.Application.Repositories
{
    public interface IReadingListItemRepository : IRepository<ReadingListItem, Guid>
    {
        IQueryable<ReadingListItem> AsQueryable();
    }
}
