namespace P.HttpService.TypedHttpClients.Base
{
    public interface IJWTHttpService : IHttpServicePost, IHttpServiceGet, IHttpServiceDelete, IHttpServicePut
    {
        void SetBearerToken(string token);
    }
}
