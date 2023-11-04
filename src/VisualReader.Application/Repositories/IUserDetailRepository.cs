namespace VisualReader
{
    public interface IUserDetailRepository : IRepository<UserDetail, Guid>
    {
        IQueryable<UserDetail> AsQueryable();
    }
}