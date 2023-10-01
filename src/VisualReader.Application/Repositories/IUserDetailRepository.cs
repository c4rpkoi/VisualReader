using VisualReader.Domain.Entities;

namespace VisualReader.Application.Repositories
{
    public interface IUserDetailRepository : IRepository<UserDetail, Guid>
    {
        IQueryable<UserDetail> AsQueryable();
    }
}