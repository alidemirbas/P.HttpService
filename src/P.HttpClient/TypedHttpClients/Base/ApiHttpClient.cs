using Newtonsoft.Json;
using P.HttpClient.TypedHttpClients.Base;
using P.HttpClient.Utility;
using System.Net.Http.Headers;
using System.Text;

namespace P.PHttpClient.TypedHttpClients.Base
{
    public abstract class ApiHttpClient :
        ApiHttpClientHelper,
        IApiHttpClientGet,
        IApiHttpClientPost,
        IApiHttpClientPut,
        IApiHttpClientDelete,
        IDisposable
    {
        public const string AuthorizationHeaderKey = "Authorization";
        public const string JSON = "application/json";

        protected readonly System.Net.Http.HttpClient _client;

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

                if (this._client.DefaultRequestHeaders.Contains(AuthorizationHeaderKey))
                    this._client.DefaultRequestHeaders.Remove(AuthorizationHeaderKey);

                if (!string.IsNullOrEmpty(_token))
                    this._client.DefaultRequestHeaders.Add(AuthorizationHeaderKey, $"Bearer {_token}");
            }
        }

        public ApiHttpClient(System.Net.Http.HttpClient client, ApiHttpClientConfiguration clientConfiguration = null)
        {
            _client = client;

            _client.BaseAddress = new Uri(clientConfiguration.BaseAddress);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JSON));
        }

        public virtual void SetToken(string token)
        {
            Token = token;
        }

        #region Delete
        public virtual async Task DeleteAsync(string urlPath, Action success = null, Action<ApiException> error = null)
        {
            var response = await _client.DeleteAsync(urlPath);

            OnResponse(response, success, error);
        }

        public virtual async Task DeleteAsync<T>(string urlPath, Action<T> success = null, Action<ApiException> error = null)
        {
            var response = await _client.DeleteAsync(urlPath);

            OnResponse(response, success, error);
        }

        public async Task DeleteAsync(string urlPath)
        {
            var response = await _client.DeleteAsync(urlPath);

            OnResponse(response);
        }

        public async Task<T> DeleteAsync<T>(string urlPath)
        {
            var response = await _client.DeleteAsync(urlPath);

            return OnResponse<T>(response);
        }
        #endregion

        #region Get
        public virtual async Task GetAsync(string urlPath, Action success = null, Action<ApiException> error = null)
        {
            var response = await _client.GetAsync(urlPath);

            OnResponse(response, success, error);
        }

        public virtual async Task GetAsync<T>(string urlPath, Action<T> success = null, Action<ApiException> error = null)
        {
            var response = await _client.GetAsync(urlPath);

            OnResponse(response, success, error);
        }

        public async Task GetAsync(string urlPath)
        {
            var response = await _client.GetAsync(urlPath);

            OnResponse(response);
        }

        public async Task<T> GetAsync<T>(string urlPath)
        {
            var response = await _client.GetAsync(urlPath);

            return OnResponse<T>(response);
        }
        #endregion

        #region Post
        public virtual async Task PostAsync(string urlPath, object data, Action success = null, Action<ApiException> error = null)
        {
            HttpContent? httpContent = default;

            if (data != null)
                httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, JSON);

            var response = await _client.PostAsync(urlPath, httpContent);

            OnResponse(response, success, error);
        }

        public virtual async Task PostAsync<T>(string urlPath, object data, Action<T> success = null, Action<ApiException> error = null)
        {
            HttpContent? httpContent = default;

            if (data != null)
                httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, JSON);

            var response = await _client.PostAsync(urlPath, httpContent);

            OnResponse(response, success, error);
        }

        public async Task PostAsync(string urlPath, object data)
        {
            HttpContent? httpContent = default;

            if (data != null)
                httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, JSON);

            var response = await _client.PostAsync(urlPath, httpContent);

            OnResponse(response);
        }

        public async Task<T> PostAsync<T>(string urlPath, object data)
        {
            HttpContent? httpContent = default;

            if (data != null)
                httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, JSON);

            var response = await _client.PostAsync(urlPath, httpContent);

            return OnResponse<T>(response);
        }
        #endregion

        #region Put
        public virtual async Task PutAsync(string urlPath, object data, Action success = null, Action<ApiException> error = null)
        {
            HttpContent? httpContent = default;

            if (data != null)
                httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, JSON);

            var response = await _client.PutAsync(urlPath, httpContent);

            OnResponse(response, success, error);
        }

        public virtual async Task PutAsync<T>(string urlPath, object data, Action<T> success = null, Action<ApiException> error = null)
        {
            HttpContent? httpContent = default;

            if (data != null)
                httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, JSON);

            var response = await _client.PutAsync(urlPath, httpContent);

            OnResponse(response, success, error);

        }

        public async Task PutAsync(string urlPath, object data)
        {
            HttpContent? httpContent = default;

            if (data != null)
                httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, JSON);

            var response = await _client.PutAsync(urlPath, httpContent);

            OnResponse(response);
        }

        public async Task<T> PutAsync<T>(string urlPath, object data)
        {
            HttpContent? httpContent = default;

            if (data != null)
                httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, JSON);

            var response = await _client.PutAsync(urlPath, httpContent);

            return OnResponse<T>(response);
        }
        #endregion

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
