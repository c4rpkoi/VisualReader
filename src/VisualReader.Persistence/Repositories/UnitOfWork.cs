using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;

namespace VisualReader
{
    public class UnitOfWork : IUnitOfWork
    {
        //public IDictionaryRepository Dictionaries { get; private set; }
        public IUserRepository Users { get; private set; }
        public IBookmarkRepository Bookmarks { get; private set; }
        public IBlockRepository Blocks { get; private set; }
        public IReadingListItemRepository ReadingListItems { get; private set; }
        public IReadingListRepository ReadingLists { get; private set; }
        public IFavoriteListRepository FavoriteLists { get; private set; }
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

        public UnitOfWork(IUserRepository users, IBookmarkRepository bookmark, IBlockRepository block, IReadingListItemRepository readingListItem, IReadingListRepository readingList, IFavoriteListRepository favoriteList, ICommentRepository comments, IChapterDataRepository chapterDatas, IChapterRepository chapters, ILoaiTruyenRepository loaiTruyens, ILoaiTruyenCuaTruyenRepository loaiTruyenCuaTruyens, ITacGiaRepository tacGias, ITacGiaTruyenRepository tacGiaTruyens, ITheLoaiRepository theLoais, ITheLoaiTruyenRepository theLoaiTruyens, ITruyenRepository truyens, VisualReaderDbContext context)
        {
            Users = users;
            Bookmarks = bookmark;
            Blocks = block;
            ReadingListItems = readingListItem;
            ReadingLists = readingList;
            FavoriteLists = favoriteList;
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