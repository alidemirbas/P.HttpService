using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using P.PHttpClient.TypedHttpClients.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.HttpClient
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = services.GetType().Assembly;
            var optionsBaseType = typeof(IOptions<>);
            var clientBaseType = typeof(ApiHttpClient);
            var clientTypes= assembly.GetTypes().Where(x => clientBaseType.IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface);
            var configurationBaseType = typeof(ApiHttpClientConfiguration);

            foreach (var clientType in clientTypes)
            {
                clientType.GetConstructors().SelectMany(x=>x.GetParameters()).Where(x=>)
            }









            var configurationTypes = assembly.GetTypes().Where(x => configurationBaseType.IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface);
            foreach (var configurationType in configurationTypes)
            {

            }

            var fileAccessApiClientConfiguration = RegisterClientConfiguration<FileAccessApiClientConfiguration>(services, configuration);
            var plmApiClientConfiguration = RegisterClientConfiguration<PLMApiClientConfiguration>(services, configuration);

            services.AddHttpClient<IPLMApiClient, PLMApiClient>(client =>
            {
                client.BaseAddress = new System.Uri(plmApiClientConfiguration.BaseAddress);
            });

            services.AddHttpClient<IFileAccessApiClient, FileAccessApiClient>(client =>
            {
                client.BaseAddress = new System.Uri(fileAccessApiClientConfiguration.BaseAddress);
            });

            return services;
        }

        private static  RegisterClientConfiguration(IServiceCollection services, IConfiguration configuration,Type configurationType)
        {
            var httpClientConfigurationsName = "HttpClientConfigurations";
            var configSection = $"{httpClientConfigurationsName}:{typeof(T).Name}";

            services.Configure<T>(configuration.GetSection(configSection));

            var serviceProvider = services.BuildServiceProvider();
            var config = serviceProvider.GetRequiredService<IOptions<T>>();

            return config.Value;
        }
    }
}
