using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using P.HttpService.TypedHttpClients.Base;
using P.HttpService.TypedHttpClients.Concrete;

namespace P.HttpService
{
    public static class ServiceCollectionExtensions
    {
        private const string HttpServiceConfigurationsSectionName = "HttpServiceConfigurations";

        public static IServiceCollection AddHttpService<THttpService, TImplementation, THttpServiceConfiguration>(this IServiceCollection services, IConfiguration configuration, string httpServiceConfigurationsSectionName = HttpServiceConfigurationsSectionName)
            where THttpServiceConfiguration : HttpServiceConfiguration
            where THttpService : class
            where TImplementation : HttpService.TypedHttpClients.Base.HttpService, THttpService
        {
            RegisterHttpServiceConfiguration<THttpServiceConfiguration>(services, configuration, httpServiceConfigurationsSectionName);

            services.AddHttpClient<THttpService, TImplementation>();

            return services;
        }

        public static IServiceCollection AddDefaultHttpService(this IServiceCollection services, IConfiguration configuration, string httpServiceConfigurationsSectionName = HttpServiceConfigurationsSectionName)
        {
            return services.AddHttpService<IDefaultHttpService, DefaultHttpService, DefaultHttpServiceConfiguration>(configuration, httpServiceConfigurationsSectionName);
        }

        private static void RegisterHttpServiceConfiguration<T>(IServiceCollection services, IConfiguration configuration, string httpServiceConfigurationsSectionName)
            where T : HttpServiceConfiguration
        {
            var configSection = $"{httpServiceConfigurationsSectionName}:{typeof(T).Name}";

            services.Configure<T>(configuration.GetSection(configSection));
        }
    }
}
