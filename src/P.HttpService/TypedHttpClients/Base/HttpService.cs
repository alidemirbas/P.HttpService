﻿using Newtonsoft.Json;
using P.HttpService.Utility;
using System.Net.Http.Headers;
using System.Text;

namespace P.HttpService.TypedHttpClients.Base
{
    public abstract class HttpService :
        HttpServiceHelper,
        IHttpServiceGet,
        IHttpServicePost,
        IHttpServicePut,
        IHttpServiceDelete,
        IDisposable
    {
        public const string AuthorizationHeaderKey = "Authorization";
        public const string JSON = "application/json";

        public virtual HttpClient HttpClient { get; }

        private string _token;
        public string Token
        {
            get
            {
                return _token;
            }
            set
            {
                _token = value;

                if (this.HttpClient.DefaultRequestHeaders.Contains(AuthorizationHeaderKey))
                    this.HttpClient.DefaultRequestHeaders.Remove(AuthorizationHeaderKey);

                if (!string.IsNullOrEmpty(_token))
                    this.HttpClient.DefaultRequestHeaders.Add(AuthorizationHeaderKey, $"Bearer {_token}");
            }
        }

        public HttpService(HttpClient httpClient, HttpServiceConfiguration clientConfiguration)
        {
            HttpClient = httpClient;

            HttpClient.BaseAddress = new Uri(clientConfiguration.BaseAddress);
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JSON));
        }

        public virtual void SetBearerToken(string token)
        {
            Token = token;
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