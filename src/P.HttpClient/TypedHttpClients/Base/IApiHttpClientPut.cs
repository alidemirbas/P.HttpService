using P.HttpClient.Utility;

namespace P.PHttpClient.TypedHttpClients.Base
{
    public interface IApiHttpClientPut : IApiHttpClient
    {
        Task PutAsync(string urlPath, object model, Action success, Action<ApiException> error);
        Task PutAsync<T>(string urlPath, object model, Action<T> success, Action<ApiException> error);

        Task PutAsync(string urlPath, object model);
        Task<T> PutAsync<T>(string urlPath, object model);
    }
}
