using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace P.HttpService.SS
{
    public static class ServiceCollectionExtensions
    {
        private const string PSSHttpServiceConfigurationsSectionName = "ssHttpServiceConfiguration";

        public static IServiceCollection AddSecuritySystemHttpService(this IServiceCollection services, IConfiguration configuration, string httpServiceConfigurationSectionName = PSSHttpServiceConfigurationsSectionName)
        {
            return services.AddHttpService<IHttpService, HttpService, HttpServiceConfiguration>(configuration, httpServiceConfigurationSectionName);
        }
    }
}
