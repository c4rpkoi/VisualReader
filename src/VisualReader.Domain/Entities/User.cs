namespace VisualReader.Domain.Entities
{
    public class User : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? UserTypeCode { get; set; }
        public string? Role { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
        public bool Verified { get; set; }
        public bool Locked { get; set; }
        public bool Deleted { get; set; }
        public UserDetail UserDetail { get; set; }
        public IEnumerable<Comment> Comments { get; set; }

        public IEnumerable<Block> Blocks { get; set; }
        public List<Bookmark> Bookmarks { get; set; }
        public ReadingList  ReadingLists { get; set; }
        public IEnumerable<FavoriteList>  FavoriteLists { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
            CreatedUtc = DateTime.UtcNow;
            UpdatedUtc = DateTime.UtcNow;
            UserTypeCode = "lu";
            Role = "administrator";
            Verified = false;
            Locked = false;
            Deleted = false;
        }
    }
}