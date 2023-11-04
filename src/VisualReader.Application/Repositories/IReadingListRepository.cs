namespace VisualReader
{
    public interface IReadingListRepository : IRepository<ReadingList, Guid>
    {
        IQueryable<ReadingList> AsQueryable();
    }
}