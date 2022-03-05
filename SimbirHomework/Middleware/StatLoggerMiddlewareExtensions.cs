using System;
using Microsoft.AspNetCore.Builder;

namespace SimbirHomework.Middleware
{
    public static class StatLoggerMiddlewareExtensions
    {
        /// <summary>
        /// 2.2.3 - ILogger middleware
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IApplicationBuilder UseStat(this IApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            
            return builder.UseMiddleware<StatLoggerMiddleware>();
        }
    }
}