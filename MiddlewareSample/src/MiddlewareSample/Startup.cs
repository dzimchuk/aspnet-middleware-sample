using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using MiddlewareSample.Infrastructure;
using MiddlewareSample.Services;

namespace MiddlewareSample
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAuthenticationService, SimpleAuthenticationService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseBasicAuthentication();

            app.Run(async context =>
            {
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Hello ASP.NET 5!");
            });
        }
    }
}
