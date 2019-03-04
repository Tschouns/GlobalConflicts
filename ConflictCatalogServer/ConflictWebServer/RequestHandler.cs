using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ConflictWebServer
{
    public static class RequestHandler
    {
        public static Task HandleRequests(HttpContext context)
        {
            return context.Response.WriteAsync("Hello World!");
        }
    }
}
