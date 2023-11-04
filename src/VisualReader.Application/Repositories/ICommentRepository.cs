namespace VisualReader
{
    public interface ICommentRepository : IRepository<Comment, Guid>
    {
        IQueryable<Comment> AsQueryable(); //phải có phương thức này để get all
    }
}