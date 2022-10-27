using System.Net;

namespace P.HttpClient.Utility
{
    public class ApiException : Exception
    {
        public ApiException(HttpStatusCode httpStatusCode, ResponseException remoteException)
            : base(APIError, remoteException)
        {
            HttpStatusCode = httpStatusCode;
        }

        private const string APIError = "API Error";

        public HttpStatusCode HttpStatusCode { get; }
    }
}
