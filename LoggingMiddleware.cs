using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace UserManagementAPI.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Log request information
            System.Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

            await _next(context);

            stopwatch.Stop();
            System.Console.WriteLine($"Response time: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
