using Microsoft.Extensions.Options;
using P.PHttpClient.TypedHttpClients.Base;

namespace P.PHttpClient.TypedHttpClients.Concrete
{
    public class ApiClient : ApiHttpClient, IApiClient
    {
        public ApiClient(System.Net.Http.HttpClient client, IOptions<ApiClientConfiguration> configurationOptions)
            : base(client, configurationOptions.Value)
        {

        }
    }
}
