namespace VisualReader
{
    public interface ITacGiaRepository : IRepository<TacGia, Guid>
    {
        public IQueryable<TacGia> AsQueryable();
    }
}