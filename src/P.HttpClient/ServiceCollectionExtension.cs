using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using P.PHttpClient.TypedHttpClients.Base;

namespace P.HttpClient
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddHttpClient<TClient, TImplementation, TApiHttpClientConfiguration>(this IServiceCollection services, IConfiguration configuration, string httpClientConfigurationsSectionName = "HttpClientConfigurations")
            where TApiHttpClientConfiguration : ApiHttpClientConfiguration
            where TClient : class
            where TImplementation : class, TClient
        {
            var clientConfiguration = RegisterClientConfiguration<TApiHttpClientConfiguration>(services, configuration, httpClientConfigurationsSectionName);

            services.AddHttpClient<TClient, TImplementation>();

            return services;
        }

        private static T RegisterClientConfiguration<T>(IServiceCollection services, IConfiguration configuration, string httpClientConfigurationsSectionName)
            where T : ApiHttpClientConfiguration
        {
            var configSection = $"{httpClientConfigurationsSectionName}:{typeof(T).Name}";

            services.Configure<T>(configuration.GetSection(configSection));

            var serviceProvider = services.BuildServiceProvider();
            var config = serviceProvider.GetRequiredService<IOptions<T>>();

            return config.Value;
        }
    }
}
