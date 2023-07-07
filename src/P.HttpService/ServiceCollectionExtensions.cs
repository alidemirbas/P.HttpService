using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace P.HttpService
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHttpService<THttpService, TImplementation, THttpServiceConfiguration>(this IServiceCollection services, IConfiguration configuration, string httpServiceConfigurationSectionName)
            where THttpServiceConfiguration : HttpServiceConfiguration
            where THttpService : class, IHttpService
            where TImplementation : HttpService<THttpServiceConfiguration>, THttpService
        {
            RegisterHttpServiceConfiguration<THttpServiceConfiguration>(services, configuration, httpServiceConfigurationSectionName);

            services.AddHttpClient<THttpService, TImplementation>();

            return services;
        }

        public static IServiceCollection AddHttpService<TImplementation, THttpServiceConfiguration>(this IServiceCollection services, IConfiguration configuration, string httpServiceConfigurationSectionName)
           where THttpServiceConfiguration : HttpServiceConfiguration
           where TImplementation : HttpService<THttpServiceConfiguration>, IHttpService
        {
            RegisterHttpServiceConfiguration<THttpServiceConfiguration>(services, configuration, httpServiceConfigurationSectionName);

            services.AddHttpClient<TImplementation>();

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
