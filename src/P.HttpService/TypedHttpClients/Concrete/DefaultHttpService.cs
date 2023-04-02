using Microsoft.Extensions.Options;
using P.HttpService.Utility;

namespace P.HttpService.TypedHttpClients.Concrete
{
    public class DefaultHttpService : Base.HttpService, IDefaultHttpService
    {
        public DefaultHttpService(HttpClient httpClient, IOptions<DefaultHttpServiceConfiguration> configurationOptions)
            : base(httpClient, configurationOptions.Value)
        {

        }

        public override Task PostAsync(string urlPath, object data, Action success, Action<ServiceException> error = null)
        {
            return base.PostAsync(urlPath, data, success, error);
        }
    }
}
