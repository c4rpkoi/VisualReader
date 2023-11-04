namespace VisualReader
{
    public interface IChapterRepository : IRepository<Chapter, Guid>
    {
        public IQueryable<Chapter> AsQueryable();
    }
}