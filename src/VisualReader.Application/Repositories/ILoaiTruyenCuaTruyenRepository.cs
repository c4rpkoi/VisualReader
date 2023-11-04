namespace VisualReader
{
    public interface ILoaiTruyenCuaTruyenRepository : IRepository<LoaiTruyenCuaTruyen, Guid>
    {
        public IQueryable<LoaiTruyenCuaTruyen> AsQueryable();
    }
}