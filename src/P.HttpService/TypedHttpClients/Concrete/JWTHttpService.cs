using Microsoft.Extensions.Options;
using P.HttpService.TypedHttpClients.Base;
using P.HttpService.Utility;
using System.Net.Http.Headers;

namespace P.HttpService.TypedHttpClients.Concrete
{
    public class JWTHttpService : Base.HttpService, IJWTHttpService
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

        public JWTHttpService(HttpClient httpClient, IOptions<JWTHttpServiceConfiguration> configurationOptions)
            : base(httpClient, configurationOptions.Value)
        {
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JSON));
        }

        public virtual void SetBearerToken(string token)
        {
            Token = token;
        }
    }
}
