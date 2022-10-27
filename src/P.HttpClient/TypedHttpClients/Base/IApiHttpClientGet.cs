using P.HttpClient.Utility;

namespace P.PHttpClient.TypedHttpClients.Base
{
    public interface IApiHttpClientGet : IApiHttpClient
    {
        Task GetAsync(string urlPath, Action success, Action<ApiException> error);
        Task GetAsync<T>(string urlPath, Action<T> success, Action<ApiException> error);

        Task GetAsync(string urlPath);
        Task<T> GetAsync<T>(string urlPath);
    }
}
