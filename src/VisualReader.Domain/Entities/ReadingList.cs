namespace VisualReader
{
    public class ReadingList : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public DateTime CreateUCT { get; set; }
        public DateTime UpdateUCT { get; set; }
        public User Users { get; set; }
        public IEnumerable<ReadingListItem> readingListItems { get; set; }
    }
}