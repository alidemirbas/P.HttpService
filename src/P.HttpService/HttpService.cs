using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using P.HttpService.Utility;
using System.Net.Http.Headers;
using System.Text;

namespace P.HttpService
{
    public abstract class HttpService<Tconfig> :
        HttpServiceHelper,
        IHttpServiceGet,
        IHttpServicePost,
        IHttpServicePut,
        IHttpServiceDelete  
        where Tconfig : HttpServiceConfiguration
    {
        public const string JSON = "application/json";

        public virtual HttpClient HttpClient { get; set; }
        public Tconfig Configuration{ get; set; }

        public HttpService(HttpClient httpClient, IOptions<Tconfig> configurationOptions)
        {
            HttpClient = httpClient;
            Configuration = configurationOptions.Value;

            HttpClient.BaseAddress = new Uri(Configuration.BaseAddress);
            HttpClient.DefaultRequestHeaders.Accept.Clear();
        }

        #region Delete
        public virtual async Task DeleteAsync(string urlPath, Action success, Action<ServiceException> error = null)
        {
            var response = await HttpClient.DeleteAsync(urlPath);

            OnResponse(response, success, error);
        }

        public virtual async Task DeleteAsync<T>(string urlPath, Action<T> success, Action<ServiceException> error = null)
        {
            var response = await HttpClient.DeleteAsync(urlPath);

            OnResponse(response, success, error);
        }

        public async Task DeleteAsync(string urlPath)
        {
            var response = await HttpClient.DeleteAsync(urlPath);

            OnResponse(response);
        }

        public async Task<T> DeleteAsync<T>(string urlPath)
        {
            var response = await HttpClient.DeleteAsync(urlPath);

            return OnResponse<T>(response);
        }
        #endregion

        #region Get
        public virtual async Task GetAsync(string urlPath, Action success, Action<ServiceException> error = null)
        {
            var response = await HttpClient.GetAsync(urlPath);

            OnResponse(response, success, error);
        }

        public virtual async Task GetAsync<T>(string urlPath, Action<T> success, Action<ServiceException> error = null)
        {
            var response = await HttpClient.GetAsync(urlPath);

            OnResponse(response, success, error);
        }

        public async Task GetAsync(string urlPath)
        {
            var response = await HttpClient.GetAsync(urlPath);

            OnResponse(response);
        }

        public async Task<T> GetAsync<T>(string urlPath)
        {
            var response = await HttpClient.GetAsync(urlPath);

            return OnResponse<T>(response);
        }
        #endregion

        #region Post
        public virtual async Task PostAsync(string urlPath, object data, Action success, Action<ServiceException> error = null)
        {
            HttpContent httpContent = default;

            if (data != null)
                httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, JSON);

            var response = await HttpClient.PostAsync(urlPath, httpContent);

            OnResponse(response, success, error);
        }

        public virtual async Task PostAsync<T>(string urlPath, object data, Action<T> success, Action<ServiceException> error = null)
        {
            HttpContent httpContent = default;

            if (data != null)
                httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, JSON);

            var response = await HttpClient.PostAsync(urlPath, httpContent);

            OnResponse(response, success, error);
        }

        public async Task PostAsync(string urlPath, object data)
        {
            HttpContent httpContent = default;

            if (data != null)
                httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, JSON);

            var response = await HttpClient.PostAsync(urlPath, httpContent);

            OnResponse(response);
        }

        public async Task<T> PostAsync<T>(string urlPath, object data)
        {
            HttpContent httpContent = default;

            if (data != null)
                httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, JSON);

            var response = await HttpClient.PostAsync(urlPath, httpContent);

            return OnResponse<T>(response);
        }
        #endregion

        #region Put
        public virtual async Task PutAsync(string urlPath, object data, Action success, Action<ServiceException> error = null)
        {
            HttpContent httpContent = default;

            if (data != null)
                httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, JSON);

            var response = await HttpClient.PutAsync(urlPath, httpContent);

            OnResponse(response, success, error);
        }

        public virtual async Task PutAsync<T>(string urlPath, object data, Action<T> success, Action<ServiceException> error = null)
        {
            HttpContent httpContent = default;

            if (data != null)
                httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, JSON);

            var response = await HttpClient.PutAsync(urlPath, httpContent);

            OnResponse(response, success, error);

        }

        public async Task PutAsync(string urlPath, object data)
        {
            HttpContent httpContent = default;

            if (data != null)
                httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, JSON);

            var response = await HttpClient.PutAsync(urlPath, httpContent);

            OnResponse(response);
        }

        public async Task<T> PutAsync<T>(string urlPath, object data)
        {
            HttpContent httpContent = default;

            if (data != null)
                httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, JSON);

            var response = await HttpClient.PutAsync(urlPath, httpContent);

            return OnResponse<T>(response);
        }
        #endregion

        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}
