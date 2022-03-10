using System;
using Microsoft.AspNetCore.Builder;

namespace SimbirHomework.Middleware
{
    public static class AdminAuthorizationMiddlewareExtensions
    {
        /// <summary>
        /// 2.2.4 - Admin middleware
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IApplicationBuilder UseAdmin(this IApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            
            return builder.UseMiddleware<AdminAuthorizationMiddleware>();
        }
    }
}