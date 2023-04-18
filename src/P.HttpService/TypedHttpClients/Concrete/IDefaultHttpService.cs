using P.HttpService.TypedHttpClients.Base;

namespace P.HttpService.TypedHttpClients.Concrete
{
    public interface IDefaultHttpService : IHttpServicePost, IHttpServiceGet, IHttpServiceDelete, IHttpServicePut
    {

    }
}
