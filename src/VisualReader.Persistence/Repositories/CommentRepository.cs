namespace VisualReader
{
    public class CommentRepository : GenericRepository<Comment, Guid>, ICommentRepository
    {
        private readonly VisualReaderDbContext _context;

        public CommentRepository(VisualReaderDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Comment> AsQueryable()
        {
            return base.AsQueryable();
        }

        protected override void Update(Comment requestObject, Comment targetObject)
        {
            targetObject.Content = requestObject.Content;//chỉ thêm trường cần update
        }
    }
}