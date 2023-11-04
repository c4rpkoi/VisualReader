namespace VisualReader
{
    public interface IUserContext
    {
        IUserContext SetId(Guid id);

        Guid Id { get; }

        IUserContext SetUserName(string userName);

        string UserName { get; }

        IUserContext? SetName(string firstName, string middleName, string lastName);

        string FirstName { get; }
        string? MiddleName { get; }
        string LastName { get; }

        IUserContext SetRole(string role);

        string Role { get; }

        IUserContext SetTokenRequest(string token);

        string Token { get; }
    }
}