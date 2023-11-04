namespace VisualReader
{
    public interface IReadingListItemRepository : IRepository<ReadingListItem, Guid>
    {
        IQueryable<ReadingListItem> AsQueryable();
    }
}