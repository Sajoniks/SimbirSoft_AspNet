using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SimbirHomework.Middleware
{
    public class StatLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public StatLoggerMiddleware(RequestDelegate next, ILogger<StatLoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Starting request processing...");
            
            var now = DateTime.UtcNow;
            await _next.Invoke(context);
            var diff = DateTime.UtcNow - now;
            
            _logger.LogInformation("Processing request done. Took {0} s.", diff.TotalSeconds);
        }
    }
}