using P.HttpClient.Utility;

namespace P.PHttpClient.TypedHttpClients.Base
{
    public interface IApiHttpClientPost : IApiHttpClient
    {
        Task PostAsync(string urlPath, object model, Action success, Action<ApiException> error);
        Task PostAsync<T>(string urlPath, object model, Action<T> success, Action<ApiException> error);

        Task PostAsync(string urlPath, object model);
        Task<T> PostAsync<T>(string urlPath, object model);
    }
}
