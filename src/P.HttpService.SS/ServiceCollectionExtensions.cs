using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace P.HttpService.SS
{
    public static class ServiceCollectionExtensions
    {
        private const string HttpServiceConfigurationsSectionName = "HttpServiceConfigurations";

        public static IServiceCollection AddDefaultHttpService(this IServiceCollection services, IConfiguration configuration, string httpServiceConfigurationsSectionName = HttpServiceConfigurationsSectionName)
        {
            return services.AddHttpService<IHttpService, HttpService, HttpServiceConfiguration>(configuration, httpServiceConfigurationsSectionName);
        }
    }
}
