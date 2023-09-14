using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace P.HttpService.SS
{
    public static class ServiceCollectionExtensions
    {
        private const string PSSHttpServiceConfigurationsSectionName = "pssHttpServiceConfiguration";

        public static IServiceCollection AddSecuritySystemHttpService(this IServiceCollection services, IConfiguration configuration, string httpServiceConfigurationSectionName = PSSHttpServiceConfigurationsSectionName, Action<HttpClient> configureClient = null)
        {
            return services.AddHttpService<IHttpService, HttpService, HttpServiceConfiguration>(configuration, httpServiceConfigurationSectionName,configureClient);
        }
    }
}
