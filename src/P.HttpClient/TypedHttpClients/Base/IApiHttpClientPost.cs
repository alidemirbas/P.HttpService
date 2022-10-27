using P.HttpClient.Utility;

namespace P.PHttpClient.TypedHttpClients.Base
{
    public interface IApiHttpClientPost : IApiHttpClient
    {
        Task PostAsync(string urlPath, object data, Action success, Action<ApiException> error);
        Task PostAsync<T>(string urlPath, object data, Action<T> success, Action<ApiException> error);

        Task PostAsync(string urlPath, object data);
        Task<T> PostAsync<T>(string urlPath, object data);
    }
}
