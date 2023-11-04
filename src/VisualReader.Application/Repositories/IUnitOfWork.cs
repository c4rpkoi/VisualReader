namespace VisualReader
{
    public interface IUnitOfWork
    {
        //IDictionaryRepository Dictionaries { get; }
        IBookmarkRepository Bookmark { get; }
        IBlockRepository Block { get; }
        IReadingListItemRepository ReadingListItem { get; }
        IReadingListRepository ReadingList { get; }
        IFavoriteListRepository FavoriteList { get; }
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