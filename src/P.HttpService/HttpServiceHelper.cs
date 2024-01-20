using Newtonsoft.Json;
using P.HttpService.Utility;
using System.Net;

namespace P.HttpService
{
    public abstract class HttpServiceHelper
    {
        protected virtual ResponseException ResponseException => new ResponseException
        {
            Message = $"Empty Response Data",
        };

        protected virtual void OnError(HttpStatusCode statusCode,string url, string responseData, Action<ServiceException> error = null)
        {
            error?.Invoke(new ServiceException(statusCode,url, GetException(responseData)));
        }

        protected virtual ServiceException OnError(HttpStatusCode statusCode, string url, string responseData)
        {
            return new ServiceException(statusCode,url, GetException(responseData));
        }

        protected virtual void OnResponse<T>(HttpResponseMessage response, Action<T> success, Action<ServiceException> error = null)
        {
            var responseData = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                var t = default(T);

                if (!string.IsNullOrEmpty(responseData))
                    t = JsonConvert.DeserializeObject<T>(responseData);

                success?.Invoke(t);

                return;
            }

            OnError(response.StatusCode,response.RequestMessage.RequestUri.ToString(), responseData, error);
        }

        protected virtual void OnResponse(HttpResponseMessage response, Action success, Action<ServiceException> error = null)
        {
            if (response.IsSuccessStatusCode)
            {
                success?.Invoke();

                return;
            }

            var responseData = response.Content.ReadAsStringAsync().Result;

            OnError(response.StatusCode, response.RequestMessage.RequestUri.ToString(), responseData, error);
        }

        protected virtual void OnResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return;

            var responseData = response.Content.ReadAsStringAsync().Result;

            throw OnError(response.StatusCode, response.RequestMessage.RequestUri.ToString(), responseData);
        }

        protected virtual T OnResponse<T>(HttpResponseMessage response)
        {
            var responseData = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                var t = default(T);

                if (!string.IsNullOrEmpty(responseData))
                    t = JsonConvert.DeserializeObject<T>(responseData);

                return t;
            }

            throw OnError(response.StatusCode, response.RequestMessage.RequestUri.ToString(), responseData);
        }

        private ResponseException GetException(string responseData)
        {
            ResponseException rex = ResponseException;

            try
            {

                if (!string.IsNullOrEmpty(responseData))
                {
                    var deserializedExp = JsonConvert.DeserializeObject<ResponseException>(responseData);

                    if (!string.IsNullOrEmpty(deserializedExp.Message))
                        rex = deserializedExp;
                }

                return rex;
            }
            catch (Exception ex)
            {
                rex = new ResponseException(ex);
            }

            return rex;
        }
    }
}
