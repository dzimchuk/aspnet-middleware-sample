using System;
using Microsoft.AspNet.Builder;

namespace MiddlewareSample.Infrastructure
{
    public static class BasicAuthenticationExtensions
    {
        public static void UseBasicAuthentication(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<BasicAuthentication>();
        }
    }
}