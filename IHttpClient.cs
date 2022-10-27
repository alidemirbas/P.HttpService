using System;
using System.Net;

namespace P.PHttpClient
{
    public interface IHttpClient : IDisposable
    {
        //Net.Http.HttpClient HttpClient { get; }

        void Get<T>(string urlPath, Action<T, string> success, Action<HttpStatusCode, RemoteException> error);//Action<> daki string'ler token
        void Get(string urlPath, Action<string> success, Action<HttpStatusCode, RemoteException> error);
        void Post<T>(string urlPath, object data, Action<T, string> success, Action<HttpStatusCode, RemoteException> error);
        void Post(string urlPath, object data, Action<string> success, Action<HttpStatusCode, RemoteException> error);

        //tokensiz
        void Get<T>(string urlPath, Action<T/*,string*/> success, Action<HttpStatusCode, RemoteException> error);
        void Get(string urlPath, Action success, Action<HttpStatusCode, RemoteException> error);
        void Post<T>(string urlPath, object data, Action<T> success, Action<HttpStatusCode, RemoteException> error);
        void Post(string urlPath, object data, Action success, Action<HttpStatusCode, RemoteException> error);
    }
}
