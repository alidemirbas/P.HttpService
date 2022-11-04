using P.PHttpClient.TypedHttpClients.Base;

namespace P.PHttpClient.TypedHttpClients.Concrete
{
    public class DefaultApiHttpClientConfiguration : ApiHttpClientConfiguration
    {
        public Dictionary<string, string> Routes { get; set; }
    }
}
