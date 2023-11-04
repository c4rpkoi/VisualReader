namespace VisualReader
{
    public interface IFavoriteListRepository : IRepository<FavoriteList, Guid>
    {
        IQueryable<FavoriteList> AsQueryable();
    }
}