namespace VisualReader
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        IQueryable<User> AsQueryable();
    }
}