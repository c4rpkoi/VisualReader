namespace VisualReader.Application.Services.Abstractions
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(string key, int? database = null);

        Task<string> GetStringAsync(string key, int? database = null);

        Task SetAsync<T>(string key, T value, TimeSpan duration, int? database = null);

        Task DeleteAsync(string key, int? database = null);
    }
}