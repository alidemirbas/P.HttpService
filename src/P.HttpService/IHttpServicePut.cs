using P.HttpService.Utility;

namespace P.HttpService
{
    public interface IHttpServicePut : IHttpService
    {
        Task PutAsync(string urlPath, object data, Action success, Action<ServiceException> error);
        Task PutAsync<T>(string urlPath, object data, Action<T> success, Action<ServiceException> error);

        Task PutAsync(string urlPath, object data);
        Task<T> PutAsync<T>(string urlPath, object data);
    }
}
