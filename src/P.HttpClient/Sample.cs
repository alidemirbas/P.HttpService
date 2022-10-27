using P.PHttpClient.TypedHttpClients.Concrete;

namespace P.HttpClient
{

    /*
    - add it to Program.cs
    
    services.AddHttpClient<IApiClient, ApiClient, ApiClientConfiguration>(configuration);
    
    - and appsettings like

    "HttpClientConfigurations": {
        "PLMApiClientConfiguration": {
          "BaseAddress": "https://foo.com",
          "ApiKey": "",
          "Routes": {
            "GetFiles": "/pim/query/api/ProductImages/GetProductTeknikFoyImageByPlmCode"
          }
        }
    }
     */

    public class Sample
    {
        private readonly IApiClient _api;

        public Sample(IApiClient api)
        {
            _api = api;
        }

        public async Task Foo()
        {

            await _api.PostAsync<T>(
                urlPath: "",
                data: new { },
                success: (t) =>
                {
                    //ok
                },
                error: (apiExceptions) =>
                {
                }
            );

            /*
            OR classic
             */

            var t = await _api.PostAsync<T>("", new { });
        }
    }
}
