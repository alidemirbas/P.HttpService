using P.HttpService.TypedHttpClients.Concrete;

namespace P.HttpService
{

    /*
    - add it to Program.cs
    
    service.AddHttpService<IDefaultHttpService, DefaultHttpService, DefaultHttpServiceConfiguration>(configuration);
    
    - and appsettings like

    "HttpServiceConfigurations": {
        "DefaultHttpServiceConfiguration": {
          "BaseAddress": "https://foo.com",
          "Routes": {
            "GetFooById": "/foo/getbyid/3"
          }
        }
    }
     */

    public class Sample
    {
        private readonly IDefaultHttpService _service;

        public Sample(IDefaultHttpService service)
        {
            _service = service;
        }


        public async Task Foo()
        {
            /*
            await _service.PostAsync<T>(
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

            var t = await _service.PostAsync<T>("", new { });
            
             */
        }

    }
}
