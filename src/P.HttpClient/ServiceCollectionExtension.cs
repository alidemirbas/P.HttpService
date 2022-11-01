using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using P.PHttpClient.TypedHttpClients.Base;
using P.PHttpClient.TypedHttpClients.Concrete;

namespace P.HttpClient
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApiHttpClient<TClient, TImplementation, TApiHttpClientConfiguration>(this IServiceCollection services, IConfiguration configuration, string httpClientConfigurationsSectionName = "HttpClientConfigurations")
            where TApiHttpClientConfiguration : ApiHttpClientConfiguration
            where TClient : class
            where TImplementation : ApiHttpClient, TClient
        {
            var clientConfiguration = RegisterClientConfiguration<TApiHttpClientConfiguration>(services, configuration, httpClientConfigurationsSectionName);

            services.AddHttpClient<TClient, TImplementation>();

            return services;
        }

        public static IServiceCollection AddDefaultApiHttpClient(this IServiceCollection services, IConfiguration configuration, string httpClientConfigurationsSectionName = "HttpClientConfigurations")
        {
            return services.AddApiHttpClient<IDefaultApiHttpClient, DefaultApiHttpClient, DefaultApiHttpClientConfiguration>(configuration,httpClientConfigurationsSectionName);
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
