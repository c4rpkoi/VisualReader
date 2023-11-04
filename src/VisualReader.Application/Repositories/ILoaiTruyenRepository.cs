namespace VisualReader
{
    public interface ILoaiTruyenRepository : IRepository<LoaiTruyen, Guid>
    {
        public IQueryable<LoaiTruyen> AsQueryable();
    }
}