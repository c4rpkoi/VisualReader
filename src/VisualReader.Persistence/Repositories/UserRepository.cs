namespace VisualReader
{
    public class UserRepository : GenericRepository<User, Guid>, IUserRepository
    {
        private readonly VisualReaderDbContext _context;

        public UserRepository(VisualReaderDbContext context) : base(context)
        {
            _context = context;
        }

        public override IQueryable<User> AsQueryable()
        {
            return base.AsQueryable();
        }

        protected override void Update(User requestObject, User targetObject)
        {
            targetObject.Verified = requestObject.Verified;
        }
    }
}