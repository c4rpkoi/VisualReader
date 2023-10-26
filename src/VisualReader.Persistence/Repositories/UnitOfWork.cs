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
        public IBookmarkRepository  Bookmarks { get; private set; }
        public IBlockRepository  Blocks { get; private set; }
        public IDsDaDocRepository  DsDaDocs { get; private set; }
        public IDsDangDocRepository  DsDangDocs { get; private set; }
        public IDsQuanTamRepository  DsQuanTams { get; private set; }



        protected VisualReaderDbContext Context { get; private set; }

        private IDbContextTransaction _transaction;

        public UnitOfWork(IUserRepository users, ICommentRepository comments, IBookmarkRepository bookmarks, IBlockRepository blocks, IDsDaDocRepository dsDaDocs, IDsDangDocRepository dsDangDocs, IDsQuanTamRepository dsQuanTams, VisualReaderDbContext context, IDbContextTransaction transaction)
        {
            Users = users;
            Comments = comments;
            Bookmarks = bookmarks;
            Blocks = blocks;
            DsDaDocs = dsDaDocs;
            DsDangDocs = dsDangDocs;
            DsQuanTams = dsQuanTams;
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