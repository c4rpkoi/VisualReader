using Microsoft.EntityFrameworkCore.Storage;
using VisualReader.Application.Repositories;
using VisualReader.Persistence.Context;

namespace VisualReader.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //public IDictionaryRepository Dictionaries { get; private set; }
        public IUserRepository Users { get; private set; }
        public ICommentRepository Comments { get; private set; }
        public IBaiVietReposytory BaiViets { get; private set; }

        protected VisualReaderDbContext Context { get; private set; }

        private IDbContextTransaction _transaction;

        public UnitOfWork(IUserRepository users, ICommentRepository comments, IBaiVietReposytory baiViets, VisualReaderDbContext context, IDbContextTransaction transaction)
        {
            Users = users;
            Comments = comments;
            BaiViets = baiViets;
            Context = context;
            _transaction = transaction;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await Context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            Context.SaveChanges();
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
            }
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }
    }
}