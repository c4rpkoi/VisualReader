namespace VisualReader.Application.Repositories
{
    public interface IUnitOfWork
    {
        //IDictionaryRepository Dictionaries { get; }
        ICommentRepository Comments { get; }
        IUserRepository Users { get; }

        Task BeginTransactionAsync();

        Task CommitAsync();

        Task RollbackAsync();
    }
}