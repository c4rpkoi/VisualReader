namespace VisualReader
{
    public class UserDetail : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }

        public UserDetail()
        {
            Id = Guid.NewGuid();
            Avatar = string.Empty;
        }
    }
}