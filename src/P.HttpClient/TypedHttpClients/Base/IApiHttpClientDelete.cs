using P.HttpClient.Utility;

namespace P.PHttpClient.TypedHttpClients.Base
{
    public interface IApiHttpClientDelete : IApiHttpClient
    {
        Task DeleteAsync(string urlPath, Action success, Action<ApiException> error);
        Task DeleteAsync<T>(string urlPath, Action<T> success, Action<ApiException> error);

        Task DeleteAsync(string urlPath);
        Task<T> DeleteAsync<T>(string urlPath);
    }
}
