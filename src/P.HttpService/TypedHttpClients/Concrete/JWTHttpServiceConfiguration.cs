using P.HttpService.TypedHttpClients.Base;

namespace P.HttpService.TypedHttpClients.Concrete
{
    public class JWTHttpServiceConfiguration : HttpServiceConfiguration
    {
        public Dictionary<string, string> Routes { get; set; }
    }
}
