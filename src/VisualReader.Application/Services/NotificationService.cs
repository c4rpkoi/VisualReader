using Microsoft.Extensions.Configuration;
using System.Text;

namespace VisualReader
{
    public class NotificationService : INotificationService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public NotificationService(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient();
        }

        public async Task SendNotificationToDevice(string deviceToken, string title, string body)
        {
            var serverKey = _configuration["Firebase:ServerKey"];
            var firebaseApiUrl = _configuration["Firebase:ApiUrl"];

            var message = new
            {
                to = deviceToken,
                notification = new
                {
                    title,
                    body
                }
            };

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(message);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"key={serverKey}");

            var response = await _httpClient.PostAsync(firebaseApiUrl, content);
            response.EnsureSuccessStatusCode();
        }
    }
}