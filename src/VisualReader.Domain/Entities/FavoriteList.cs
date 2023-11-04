namespace VisualReader
{
    public class FavoriteList : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdTruyen { get; set; }
        public DateTime CreateUCT { get; set; }
        public DateTime UpdateUCT { get; set; }
        public User Users { get; set; }
        public Truyen Truyens { get; set; }
    }
}