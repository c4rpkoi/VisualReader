namespace VisualReader
{
    public class Bookmark : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdChapter { get; set; }
        public string PageIndex { get; set; }
        public DateTime CreateUCT { get; set; }
        public DateTime UpdateUCT { get; set; }
        public Chapter Chapters { get; set; }
        public User Users { get; set; }
    }
}