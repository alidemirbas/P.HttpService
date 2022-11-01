using P.PHttpClient.TypedHttpClients.Base;

namespace P.PHttpClient.TypedHttpClients.Concrete
{
    public interface IDefaultApiHttpClient : IApiHttpClientPost, IApiHttpClientGet, IApiHttpClientDelete, IApiHttpClientPut
    {
    }
}
