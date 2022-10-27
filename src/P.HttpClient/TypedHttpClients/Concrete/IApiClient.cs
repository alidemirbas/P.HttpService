using P.PHttpClient.TypedHttpClients.Base;

namespace P.PHttpClient.TypedHttpClients.Concrete
{
    public interface IApiClient : IApiHttpClientPost, IApiHttpClientGet, IApiHttpClientDelete, IApiHttpClientPut
    {
    }
}
