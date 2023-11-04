namespace VisualReader
{
    public interface ITheLoaiRepository : IRepository<TheLoai, Guid>
    {
        public IQueryable<TheLoai> AsQueryable();
    }
}