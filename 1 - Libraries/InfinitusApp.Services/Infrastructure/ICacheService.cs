using System.Threading.Tasks;

namespace InfinitusApp.Services.Infrastructure
{
    public interface ICacheService
    {
        //Task Initialize();

        Task Reset();

        Task<T> Get<T>(string key);

        Task Put<T>(string key, T value);

        Task Delete(string key);
    }
}