using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

var issss=typeof(IEnumerable<IFormFile>).IsAssignableFrom(typeof(List<FormFile>));
Console.WriteLine(issss);
Console.ReadLine();