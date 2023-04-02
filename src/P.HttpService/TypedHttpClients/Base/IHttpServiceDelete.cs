using P.HttpService.Utility;

namespace P.HttpService.TypedHttpClients.Base
{
    public interface IHttpServiceDelete : IHttpService
    {
        Task DeleteAsync(string urlPath, Action success, Action<ServiceException> error);
        Task DeleteAsync<T>(string urlPath, Action<T> success, Action<ServiceException> error);

        Task DeleteAsync(string urlPath);
        Task<T> DeleteAsync<T>(string urlPath);
    }
}
