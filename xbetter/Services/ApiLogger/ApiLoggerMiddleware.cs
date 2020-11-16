using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace xbetter.Services.ApiLogger
{
    public class ApiLoggerMiddleware
    {
        private readonly ILogger<ApiLoggerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ApiLoggerMiddleware(ILogger<ApiLoggerMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Request starting {data}",$"[{context.Request.Method} {context.Request.Path}]");
            
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            await _next.Invoke(context);

            stopwatch.Stop();

            _logger.LogInformation("Request finished {data}", $"[{context.Request.Method} {context.Request.Path} {stopwatch.Elapsed.TotalMilliseconds} {context.Response.StatusCode}]");
        }
    }

    public static class ApiLoggerMiddlewareExtentions
    {
        public static void UseApiLoggerMiddleware(this IApplicationBuilder app)
            => app.UseMiddleware<ApiLoggerMiddleware>();
    }
}
