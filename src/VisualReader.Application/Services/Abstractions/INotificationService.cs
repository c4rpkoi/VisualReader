namespace VisualReader.Application.Services.Abstractions
{
    public interface INotificationService
    {
        Task SendNotificationToDevice(string deviceToken, string title, string body);
    }
}