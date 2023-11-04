namespace VisualReader
{
    public interface IChapterDataRepository : IRepository<ChapterData, Guid>
    {
        public IQueryable<ChapterData> AsQueryable();
    }
}