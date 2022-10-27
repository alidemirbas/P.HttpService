namespace P.PHttpClient.TypedHttpClients.Base
{
    public abstract class STSClientConfiguration : ApiHttpClientConfiguration
    {
        public string ApiKey { get; set; }
        public string ConsumerName { get; set; }
    }
}
