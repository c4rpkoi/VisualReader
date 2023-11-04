namespace VisualReader
{
    public class Comment : IEntity<Guid> //nhớ kế thừa cái ientity này
    {
        public Guid Id { get; set; }
        public Guid? PostId { get; set; }
        public Guid? ChapterId { get; set; }
        public Guid? BookId { get; set; }
        public Guid? UserId { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public string Content { get; set; }
        public User? User { get; set; }
        public Chapter? Chapter { get; set; }
        public Book? Book { get; set; }
        public Post? Post { get; set; }
    }
}