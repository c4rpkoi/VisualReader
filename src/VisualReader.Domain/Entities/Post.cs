namespace VisualReader
{
    public class Post : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        //bảng dummy chúng m tự sửa
    }
}