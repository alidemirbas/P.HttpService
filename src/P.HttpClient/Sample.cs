using P.PHttpClient.TypedHttpClients.Concrete;

namespace P.HttpClient
{

    /*
    - add it to Program.cs
    
    services.AddHttpClient<IDefaultApiHttpClient, DefaultApiHttpClient, DefaultApiHttpClientConfiguration>(configuration);
    
    - and appsettings like

    "HttpClientConfigurations": {
        "DefaultApiHttpClientConfiguration": {
          "BaseAddress": "https://foo.com",
          "Routes": {
            "GetFooById": "/foo/getbyid/3"
          }
        }
    }
     */

    public class Sample
    {
        private readonly IDefaultApiHttpClient _api;

        public Sample(IDefaultApiHttpClient api)
        {
            _api = api;
        }

        /*
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

            //OR classic

            var t = await _api.PostAsync<T>("", new { });
        }
        */
    }
}
