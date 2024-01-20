using System.Net;

namespace P.HttpService.Utility
{
    public class ServiceException : Exception
    {
        public ServiceException(HttpStatusCode httpStatusCode, string url, ResponseException remoteException)
            : base(ServiceError, remoteException)
        {
            HttpStatusCode = httpStatusCode;
            Url = url;
        }

        private const string ServiceError = "Service Error";

        public HttpStatusCode HttpStatusCode { get; }
        public string Url { get; }
    }
}
