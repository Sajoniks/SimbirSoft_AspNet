using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SimbirHomework.Middleware
{
    public class AdminAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public AdminAuthorizationMiddleware(RequestDelegate next, ILogger<AdminAuthorizationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var header = context.Request.Headers["Authorization"];
                if (header.Count == 0) throw new KeyNotFoundException();

                var keyPair = header[0].Split(':');
                if (keyPair.Length == 1) throw new KeyNotFoundException();

                if (keyPair[0] == "Basic admin" && keyPair[1] == "admin")
                {
                    await _next.Invoke(context);
                }
                else
                {
                    throw new KeyNotFoundException();
                }
            }
            catch (KeyNotFoundException e)
            {
                // No auth
                _logger.LogCritical("Request aborted - authorization needed.");
            }
        }
    }
}