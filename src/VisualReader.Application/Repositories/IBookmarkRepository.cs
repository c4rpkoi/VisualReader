namespace VisualReader
{
    public interface IBookmarkRepository : IRepository<Bookmark, Guid>
    {
        IQueryable<Bookmark> AsQueryable();
    }
}