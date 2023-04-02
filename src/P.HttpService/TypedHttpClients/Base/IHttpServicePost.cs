using P.HttpService.Utility;

namespace P.HttpService.TypedHttpClients.Base
{
    public interface IHttpServicePost : IHttpService
    {
        Task PostAsync(string urlPath, object data, Action success, Action<ServiceException> error);
        Task PostAsync<T>(string urlPath, object data, Action<T> success, Action<ServiceException> error);

        Task PostAsync(string urlPath, object data);
        Task<T> PostAsync<T>(string urlPath, object data);
    }
}
