using Microsoft.EntityFrameworkCore.Storage;
using VisualReader.Application.Repositories;
using VisualReader.Domain.Entities;
using VisualReader.Persistence.Context;

namespace VisualReader.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //public IDictionaryRepository Dictionaries { get; private set; }
        public IUserRepository Users { get; private set; }
        public ICommentRepository Comments { get; private set; }
        public IChapterDataRepository ChapterDatas { get; private set; }
        public IChapterRepository Chapters { get; private set; }
        public ILoaiTruyenRepository LoaiTruyens { get; private set; }
        public ILoaiTruyenCuaTruyenRepository LoaiTruyenCuaTruyens { get; private set; }
        public ITacGiaRepository TacGias { get; private set; }
        public ITacGiaTruyenRepository TacGiaTruyens { get; private set; }
        public ITheLoaiRepository TheLoais { get; private set; }
        public ITheLoaiTruyenRepository TheLoaiTruyens { get; private set; }
        public ITruyenRepository Truyens { get; private set; }

        protected VisualReaderDbContext Context { get; private set; }

        private IDbContextTransaction _transaction;

        public IBookmarkRepository Bookmark { get; private set; }
        public IBlockRepository Block { get; private set; }
        public IReadingListItemRepository ReadingListItem { get; private set; }
        public IReadingListRepository ReadingList { get; private set; }
        public IFavoriteListRepository FavoriteList { get; private set; }

        public UnitOfWork(IUserRepository users, ICommentRepository comments, IChapterDataRepository chapterDatas, IChapterRepository chapters, ILoaiTruyenRepository loaiTruyens, ILoaiTruyenCuaTruyenRepository loaiTruyenCuaTruyens, ITacGiaRepository tacGias, ITacGiaTruyenRepository tacGiaTruyens, ITheLoaiRepository theLoais, ITheLoaiTruyenRepository theLoaiTruyens, ITruyenRepository truyens, VisualReaderDbContext context, IDbContextTransaction transaction, IBookmarkRepository bookmark, IBlockRepository block, IReadingListItemRepository readingListItem, IReadingListRepository readingList, IFavoriteListRepository favoriteList)
        {
            Users = users;
            Comments = comments;
            ChapterDatas = chapterDatas;
            Chapters = chapters;
            LoaiTruyens = loaiTruyens;
            LoaiTruyenCuaTruyens = loaiTruyenCuaTruyens;
            TacGias = tacGias;
            TacGiaTruyens = tacGiaTruyens;
            TheLoais = theLoais;
            TheLoaiTruyens = theLoaiTruyens;
            Truyens = truyens;
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