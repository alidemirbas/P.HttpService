Do you like AJAX syntax?
What about to do something like that in C# ?

```csharp
services.AddDefaultHttpService(configuration);

...

public class Sample
    {
        private readonly IDefaultHttpService _service;

        public Sample(IDefaultHttpService service)
        {
            _service = service;
        }

        public async Task Foo()
        {

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

            /*
            OR classic
             */

            var t = await _service.PostAsync<T>("", new { });
        }
    }
```

But I'm sure you wanna do it via "tab tab" 😊 so don't forget to import code snippets in the project.
https://github.com/alidemirbas/P.PHttpClient/blob/master/ApiPost.snippet

It's that much easy 😏
