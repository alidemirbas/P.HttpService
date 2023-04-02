using P.HttpService.Utility;

namespace P.HttpService.TypedHttpClients.Base
{
    public interface IHttpServiceGet : IHttpService
    {
        Task GetAsync(string urlPath, Action success, Action<ServiceException> error);
        Task GetAsync<T>(string urlPath, Action<T> success, Action<ServiceException> error);

        Task GetAsync(string urlPath);
        Task<T> GetAsync<T>(string urlPath);
    }
}
