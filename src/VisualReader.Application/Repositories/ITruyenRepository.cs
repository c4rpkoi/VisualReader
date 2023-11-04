namespace VisualReader
{
    public interface ITruyenRepository : IRepository<Truyen, Guid>
    {
        IQueryable<Truyen> AsQueryable();
    }
}