Do you like AJAX syntax?
What about to do something like that in C# ?

```csharp
using (var api = new ApiClient(this.ApiAccessToken))
{
    api.Post(
      urlPath: "/authentication/signin",
      data: credential,
      success: (data) =>
      {
           result = Ok();
      },
      error: (httpStatusCode, httpError) =>
      {

      });
}
```

But I'm sure you wanna do it via "tab tab" 😊 so don't forget to check out code snippets in the project.
https://github.com/alidemirbas/P.HttpClient/blob/master/ApiPost.snippet

It's that much easy 😏
