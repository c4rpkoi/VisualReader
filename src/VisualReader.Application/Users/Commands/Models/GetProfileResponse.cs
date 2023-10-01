namespace VisualReader.Application.Users.Commands.Models
{
    public class GetProfileResponse
    {
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }

        public GetProfileResponse(string phoneNumber, string firstName, string middleName, string lastName, string address, string avatar)
        {
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Address = address;
            Avatar = avatar;
        }
    }
}