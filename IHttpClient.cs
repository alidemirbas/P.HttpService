using System;
using System.Net;

namespace P.HttpClient
{
    public interface IHttpClient : IDisposable
    {
        //Net.Http.HttpClient HttpClient { get; }

        void Get<T>(string urlPath, Action<T, string> success, Action<HttpStatusCode, Exception> httpError);//Action<> daki string'ler token
        void Get(string urlPath, Action<string> success, Action<HttpStatusCode, Exception> httpError);
        void Post<T>(string urlPath, object data, Action<T, string> success, Action<HttpStatusCode, Exception> httpError);
        void Post(string urlPath, object data, Action<string> success, Action<HttpStatusCode, Exception> httpError);

        //tokensiz
        void Get<T>(string urlPath, Action<T/*,string*/> success, Action<HttpStatusCode, Exception> httpError);
        void Get(string urlPath, Action success, Action<HttpStatusCode, Exception> httpError);
        void Post<T>(string urlPath, object data, Action<T> success, Action<HttpStatusCode, Exception> httpError);
        void Post(string urlPath, object data, Action success, Action<HttpStatusCode, Exception> httpError);
    }
}
