namespace P.HttpService
{
    public interface IHttpService: IDisposable
    {
        HttpClient HttpClient { get; }
    }
}
