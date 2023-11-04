namespace VisualReader
{
    public interface INotificationService
    {
        Task SendNotificationToDevice(string deviceToken, string title, string body);
    }
}