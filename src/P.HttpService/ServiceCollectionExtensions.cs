using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace P.HttpService
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHttpService<THttpService, TImplementation, THttpServiceConfiguration>(this IServiceCollection services, IConfiguration configuration, string httpServiceConfigurationsSectionName)
            where THttpServiceConfiguration : HttpServiceConfiguration
            where THttpService : class
            where TImplementation : HttpService, THttpService
        {
            RegisterHttpServiceConfiguration<THttpServiceConfiguration>(services, configuration, httpServiceConfigurationsSectionName);

            services.AddHttpClient<THttpService, TImplementation>();

            return services;
        }

        private static void RegisterHttpServiceConfiguration<T>(IServiceCollection services, IConfiguration configuration, string httpServiceConfigurationsSectionName)
            where T : HttpServiceConfiguration
        {
            var configSection = $"{httpServiceConfigurationsSectionName}:{typeof(T).Name}";

            services.Configure<T>(configuration.GetSection(configSection));
        }
    }
}
