using System;
using System.Net;

namespace P.HttpClient
{
    public class ApiExceptionThrower
    {
        public static void WrapAndThrow(HttpStatusCode httpStatusCode, RemoteException remoteException)
        {
            var apiExp = new ApiException(httpStatusCode, remoteException);
            throw apiExp;
        }
    }
}
