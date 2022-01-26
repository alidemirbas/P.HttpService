
using System;
using System.Net;
using System.Runtime.Serialization;

namespace P.HttpClient
{
    public class ApiException : Exception
    {
        public ApiException(HttpStatusCode httpStatusCode, RemoteException remoteException) 
            : base(APIError, remoteException)
        {
            HttpStatusCode = httpStatusCode;
        }

        private const string APIError = "API Error";

        public HttpStatusCode HttpStatusCode { get; }
    }

    [DataContract]
    public class RemoteException : Exception
    {
        [DataMember]
        public new string Message { get; set; }
        [DataMember]
        public new string StackTrace { get; set; }
        [DataMember]
        public new RemoteException InnerException { get; set; }
    }
}
