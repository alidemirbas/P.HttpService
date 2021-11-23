using System;
using System.Net;

namespace P.HttpClient
{
    public class ApiExceptionThrower
    {
        public static void WrapAndThrow(HttpStatusCode httpStatusCode, Exception innerException)
        {
            var apiExp = new ApiException(httpStatusCode, innerException);
            throw apiExp;
        }
    }
}
