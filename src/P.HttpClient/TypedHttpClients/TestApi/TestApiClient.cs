using Microsoft.Extensions.Options;
using P.PHttpClient.TypedHttpClients.Base;

namespace P.PHttpClient.TypedHttpClients.TestApi
{
    public class TestApiClient : ApiHttpClient, ITestApiClient
    {
        public TestApiClient(System.Net.Http.HttpClient client, IOptions<TestApiClientConfiguration> configurationOptions)
            : base(client, configurationOptions.Value)
        {

        }
    }
}
