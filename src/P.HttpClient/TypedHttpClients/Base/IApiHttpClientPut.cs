using P.HttpClient.Utility;

namespace P.PHttpClient.TypedHttpClients.Base
{
    public interface IApiHttpClientPut : IApiHttpClient
    {
        Task PutAsync(string urlPath, object data, Action success, Action<ApiException> error);
        Task PutAsync<T>(string urlPath, object data, Action<T> success, Action<ApiException> error);

        Task PutAsync(string urlPath, object data);
        Task<T> PutAsync<T>(string urlPath, object data);
    }
}
