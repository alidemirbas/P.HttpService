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
            RegisterClientConfiguration<TApiHttpClientConfiguration>(services, configuration, httpClientConfigurationsSectionName);

            services.AddHttpClient<TClient, TImplementation>();

            return services;
        }

        public static IServiceCollection AddDefaultApiHttpClient(this IServiceCollection services, IConfiguration configuration, string httpClientConfigurationsSectionName = "HttpClientConfigurations")
        {
            return services.AddApiHttpClient<IDefaultApiHttpClient, DefaultApiHttpClient, DefaultApiHttpClientConfiguration>(configuration,httpClientConfigurationsSectionName);
        }

        private static void RegisterClientConfiguration<T>(IServiceCollection services, IConfiguration configuration, string httpClientConfigurationsSectionName)
            where T : ApiHttpClientConfiguration
        {
            var configSection = $"{httpClientConfigurationsSectionName}:{typeof(T).Name}";

            services.Configure<T>(configuration.GetSection(configSection));
        }
    }
}
