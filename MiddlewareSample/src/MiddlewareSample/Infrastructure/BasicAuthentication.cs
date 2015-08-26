using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace MiddlewareSample.Infrastructure
{
    public class BasicAuthentication
    {
        private readonly RequestDelegate next;

        public BasicAuthentication(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IAuthenticationService authenticationService)
        {
            try
            {
                var parser = new BasicAuthenticationParser(context);
                var username = parser.GetUsername();
                var password = parser.GetPassword();

                await authenticationService.AuthenticateAsync(username, password);
                await next(context);
            }
            catch (InvalidCredentialsException)
            {
                context.Response.StatusCode = 401;
                context.Response.Headers.Add("WWW-Authenticate", new[] { "Basic" });
            }
        }
    }
}