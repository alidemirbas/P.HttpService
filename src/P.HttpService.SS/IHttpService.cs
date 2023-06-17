namespace P.HttpService.SS
{
    public interface IHttpService : 
        IHttpServicePost,
        IHttpServiceGet, 
        IHttpServiceDelete,
        IHttpServicePut
    {
        void SetBearerToken(string token);
    }
}
