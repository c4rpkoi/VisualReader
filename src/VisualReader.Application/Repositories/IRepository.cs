using VisualReader.Domain.Entities;

namespace VisualReader.Application.Repositories
{
    public interface IRepository<TModel, TKey> where TModel : class, IEntity<TKey>
    {
        Task<TModel> AddAsync(TModel e);

        Task<TModel> UpdateAsync(TKey key, TModel e);

        Task<bool> RemoveAsync(TKey key);

        Task<TModel> FindAsync(TKey id);
    }
}