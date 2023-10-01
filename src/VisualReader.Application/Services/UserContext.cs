using VisualReader.Application.Services.Abstractions;

namespace VisualReader.Application.Services
{
    public class UserContext : IUserContext
    {
        private Guid _id;
        private string _userName;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _role;
        private string _token;

        public Guid Id => _id;
        public string UserName => _userName;
        public string FirstName => _firstName;
        public string MiddleName => _middleName;
        public string LastName => _lastName;
        public string Role => _role;
        public string Token => _token;

        public IUserContext SetId(Guid id)
        {
            _id = id;
            return this;
        }

        public IUserContext SetUserName(string userName)
        {
            _userName = userName;
            return this;
        }

        public IUserContext SetName(string firstName, string middleName, string lastName)
        {
            _firstName = firstName;
            _middleName = middleName;
            _lastName = lastName;
            return this;
        }

        public IUserContext SetRole(string role)
        {
            _role = role;
            return this;
        }

        public IUserContext SetTokenRequest(string token)
        {
            _token = token;
            return this;
        }
    }
}