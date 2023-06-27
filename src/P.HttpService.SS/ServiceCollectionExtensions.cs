using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace P.HttpService.SS
{
    public static class ServiceCollectionExtensions
    {
        private const string PSSHttpServiceConfigurationsSectionName = "ssHttpServiceConfiguration";

        public static IServiceCollection AddHttpService(this IServiceCollection services, IConfiguration configuration, string httpServiceConfigurationSectionName = PSSHttpServiceConfigurationsSectionName)
        {
            return services.AddHttpService<IHttpService, HttpService, HttpServiceConfiguration>(configuration, httpServiceConfigurationSectionName);
        }

        public static IServiceCollection AddHttpService<T, TConfig>(this IServiceCollection services, IConfiguration configuration, string httpServiceConfigurationSectionName)
            where TConfig : HttpServiceConfiguration
            where T : HttpService<TConfig>
        {
            return services.AddHttpService<IHttpService, T, TConfig>(configuration, httpServiceConfigurationSectionName);
        }

        public static IServiceCollection AddHttpService<T>(this IServiceCollection services, IConfiguration configuration, string httpServiceConfigurationSectionName)
            where T : HttpService<HttpServiceConfiguration>
        {
            return services.AddHttpService<T, HttpServiceConfiguration>(configuration, httpServiceConfigurationSectionName);
        }
    }
}
