namespace VisualReader
{
    public interface ITacGiaTruyenRepository : IRepository<TacGiaTruyen, Guid>
    {
        public IQueryable<TacGiaTruyen> AsQueryable();
    }
}