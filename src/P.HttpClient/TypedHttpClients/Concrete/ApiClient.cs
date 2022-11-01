using Microsoft.Extensions.Options;
using P.HttpClient.Utility;
using P.PHttpClient.TypedHttpClients.Base;

namespace P.PHttpClient.TypedHttpClients.Concrete
{
    public class ApiClient : ApiHttpClient, IApiClient
    {
        public ApiClient(System.Net.Http.HttpClient client, IOptions<ApiClientConfiguration> configurationOptions)
            : base(client, configurationOptions.Value)
        {

        }

        public override Task PostAsync(string urlPath, object data, Action success = null, Action<ApiException> error = null)
        {
            return base.PostAsync(urlPath, data, success, error);
        }
    }
}
