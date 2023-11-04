namespace VisualReader
{
    public class Book : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}