namespace VisualReader
{
    public interface ITheLoaiTruyenRepository : IRepository<TheLoaiTruyen, Guid>
    {
        public IQueryable<TheLoaiTruyen> AsQueryable();
    }
}