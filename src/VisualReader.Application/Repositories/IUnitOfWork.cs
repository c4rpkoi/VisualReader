namespace VisualReader
{
    public interface IUnitOfWork
    {
        //IDictionaryRepository Dictionaries { get; }
        IBookmarkRepository Bookmarks { get; }
        IBlockRepository Blocks { get; }
        IReadingListItemRepository ReadingListItems { get; }
        IReadingListRepository ReadingLists { get; }
        IFavoriteListRepository FavoriteLists { get; }
        ICommentRepository Comments { get; }
        IChapterDataRepository ChapterDatas { get; }
        IChapterRepository Chapters { get;   }
        ILoaiTruyenRepository LoaiTruyens { get; }
        ILoaiTruyenCuaTruyenRepository LoaiTruyenCuaTruyens { get; }
        ITacGiaRepository TacGias { get; }
        ITacGiaTruyenRepository TacGiaTruyens { get; }
        ITheLoaiRepository TheLoais { get; }
        ITheLoaiTruyenRepository TheLoaiTruyens { get; }
        ITruyenRepository Truyens { get; }
        IUserRepository Users { get; }

        Task BeginTransactionAsync();

        Task CommitAsync();

        Task RollbackAsync();
    }
}