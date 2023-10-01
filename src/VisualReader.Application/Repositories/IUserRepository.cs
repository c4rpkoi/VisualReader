using VisualReader.Domain.Entities;

namespace VisualReader.Application.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        IQueryable<User> AsQueryable();
    }
}