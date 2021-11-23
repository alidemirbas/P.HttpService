
using System;
using System.Net;

namespace P.HttpClient
{
    public class ApiException : Exception
    {
        public ApiException(HttpStatusCode httpStatusCode, Exception innerException) 
            : base(APIError, innerException)
        {
            HttpStatusCode = httpStatusCode;
        }

        private const string APIError = "API Error";

        public HttpStatusCode HttpStatusCode { get; }
    }
}
