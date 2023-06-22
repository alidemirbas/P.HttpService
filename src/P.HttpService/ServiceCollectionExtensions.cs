using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace P.HttpService
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHttpService<THttpService, TImplementation, THttpServiceConfiguration>(this IServiceCollection services, IConfiguration configuration, string httpServiceConfigurationSectionName)
            where THttpServiceConfiguration : HttpServiceConfiguration
            where THttpService : class
            where TImplementation : HttpService, THttpService
        {
            RegisterHttpServiceConfiguration<THttpServiceConfiguration>(services, configuration, httpServiceConfigurationSectionName);

            services.AddHttpClient<THttpService, TImplementation>();

            return services;
        }

        private static void RegisterHttpServiceConfiguration<T>(IServiceCollection services, IConfiguration configuration, string httpServiceConfigurationSectionName)
            where T : HttpServiceConfiguration
        {
            var configSection = $"httpServiceConfigurations:{httpServiceConfigurationSectionName}";

            services.Configure<T>(configuration.GetSection(configSection));
        }
    }
}
