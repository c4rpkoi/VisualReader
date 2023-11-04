namespace VisualReader
{
    public interface IBlockRepository : IRepository<Block, Guid>
    {
        IQueryable<Block> AsQueryable();
    }
}