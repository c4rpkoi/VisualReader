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

        public UnitOfWork(VisualReaderDbContext context/*, IDictionaryRepository dictionaryRepository*/, IUserRepository userRepository, ICommentRepository commentRepository, IChapterDataRepository chapterDatas, IChapterRepository chapters, ILoaiTruyenRepository loaiTruyens, ILoaiTruyenCuaTruyenRepository loaiTruyenCuaTruyens, ITacGiaRepository tacGias, ITacGiaTruyenRepository tacGiaTruyens, ITheLoaiRepository theLoais, ITheLoaiTruyenRepository theLoaiTruyens, ITruyenRepository truyens)
        {
            Context = context;
            //Dictionaries = dictionaryRepository;
            Users = userRepository;
            Comments = commentRepository;
            ChapterDatas = chapterDatas;
            Chapters = chapters;
            LoaiTruyens = loaiTruyens;
            LoaiTruyenCuaTruyens = loaiTruyenCuaTruyens;
            TacGias = tacGias;
            TacGiaTruyens = tacGiaTruyens;
            TheLoaiTruyens = theLoaiTruyens;
            Truyens = truyens;
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