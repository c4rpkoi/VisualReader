namespace VisualReader
{
    public interface ITacGiaTruyenRepository
    {
        public IQueryable<TacGiaTruyen> AsQueryable();
    }
}