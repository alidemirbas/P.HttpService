namespace P.HttpService.TypedHttpClients.Base
{
    public interface IHttpService
    {
        System.Net.Http.HttpClient HttpClient { get; }

        void SetBearerToken(string token);
    }
}
