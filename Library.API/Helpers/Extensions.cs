using Microsoft.AspNetCore.Http;

namespace Library.API.Helpers
{
    public static class Extensions // name this specific to what it is extending, e.g. HttpResponseExtensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}