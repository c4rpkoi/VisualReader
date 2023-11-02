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

        protected VisualReaderDbContext Context { get; private set; }

        private IDbContextTransaction _transaction;

        public IBookmarkRepository Bookmark { get; private set; }
        public IBlockRepository Block { get; private set; }
        public IReadingListItemRepository ReadingListItem { get; private set; }
        public IReadingListRepository ReadingList { get; private set; }
        public IFavoriteListRepository FavoriteList { get; private set; }

        public UnitOfWork(IUserRepository users, ICommentRepository comments, VisualReaderDbContext context, IDbContextTransaction transaction, IBookmarkRepository bookmark, IBlockRepository block, IReadingListItemRepository readingListItem, IReadingListRepository readingList, IFavoriteListRepository favoriteList)
        {
            Users = users;
            Comments = comments;
            Context = context;
            _transaction = transaction;
            Bookmark = bookmark;
            Block = block;
            ReadingListItem = readingListItem;
            ReadingList = readingList;
            FavoriteList = favoriteList;
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