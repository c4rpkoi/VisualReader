namespace VisualReader.Application.Models.Bases
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public string Type { get; set; }
        public double Expired { get; set; }

        public TokenResponse(string accessToken, string type, int expired)
        {
            AccessToken = accessToken;
            Type = type;
            Expired = expired;
        }
    }

    public class TokenRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}