using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace P.HttpService.SS
{
    public class HttpService<TConfig> : P.HttpService.HttpService<TConfig>, IHttpService
        where TConfig : HttpServiceConfiguration
    {
        public const string AuthorizationHeaderKey = "Authorization";

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

        public HttpService(HttpClient httpClient, IOptions<TConfig> configurationOptions)
            : base(httpClient, configurationOptions)
        {
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JSON));
        }

        public virtual void SetBearerToken(string token)
        {
            Token = token;
        }
    }

    public class HttpService : HttpService<HttpServiceConfiguration>, IHttpService
    {
        public HttpService(HttpClient httpClient, IOptions<HttpServiceConfiguration> configurationOptions) : base(httpClient, configurationOptions)
        {
        }
    }
}
