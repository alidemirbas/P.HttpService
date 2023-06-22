using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace P.HttpService.SS
{
    public static class ServiceCollectionExtensions
    {
        private const string PSSHttpServiceConfigurationsSectionName = "ssHttpServiceConfiguration";

        public static IServiceCollection AddSSHttpService(this IServiceCollection services, IConfiguration configuration, string httpServiceConfigurationsSectionName = PSSHttpServiceConfigurationsSectionName)
        {
            return services.AddHttpService<IHttpService, HttpService, HttpServiceConfiguration>(configuration, httpServiceConfigurationsSectionName);
        }
    }
}
