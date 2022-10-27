using P.PHttpClient.TypedHttpClients.Base;

namespace P.PHttpClient.TypedHttpClients.TestApi
{
    public class TestApiClientConfiguration : STSClientConfiguration
    {
        public TestFileClientConfigurationRoutes Routes { get; set; }
    }

    public class TestFileClientConfigurationRoutes
    {
        public string GetFiles { get; set; }
    }
}
