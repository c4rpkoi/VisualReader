using Microsoft.EntityFrameworkCore;

namespace VisualReader
{
    public abstract class GenericRepository<TModel, TKey> : IRepository<TModel, TKey> where TModel : class, IEntity<TKey> where TKey : IEquatable<TKey>
    {
        protected DbContext Context { get; private set; }

        public GenericRepository(DbContext context)
        {
            Context = context;
        }

        public virtual async Task<TModel> AddAsync(TModel e)
        {
            DbSet<TModel> Collection = Context.Set<TModel>();
            await Collection.AddAsync(e);
            return e;
        }

        public virtual async Task<TModel> UpdateAsync(TKey key, TModel e)
        {
            TModel trackingEntity = await FindAsync(key);
            if (trackingEntity != null)
            {
                Update(e, trackingEntity);
            }

            return e;
        }

        public virtual Task<TModel> FindAsync(TKey id)
        {
            return AsQueryable().FirstOrDefaultAsync((TModel e) => e.Id.Equals(id));
        }

        public virtual async Task<bool> RemoveAsync(TKey key)
        {
            TModel entity = await FindAsync(key);
            if (entity != null)
            {
                DbSet<TModel> Collection = Context.Set<TModel>();
                Collection.Remove(entity);
                return true;
            }

            return false;
        }

        public virtual IQueryable<TModel> AsQueryable()
        {
            return Context.Set<TModel>();
        }

        protected abstract void Update(TModel requestObject, TModel targetObject);

        public virtual IQueryable<TModel> AsFetchable()
        {
            return AsQueryable();
        }
    }
}