using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ConsoleToWeb
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services){}
        public void Configure(IApplicationBuilder app) {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                    {
                        await context.Response.WriteAsync("Hello this is a Test from Dharvo's Inc. VybzTech");
                    });
                endpoints.MapGet("/test", async context =>
                    {
                        await context.Response.WriteAsync("Hello this is a TestPage from Test's Inc. VybzTech");
                    });
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello this is a Test from Use - I \n VybzTech \n");
                await next();
                await context.Response.WriteAsync("Hello this is a Test from Use - II \n VybzTech \n");
                await next();
                await context.Response.WriteAsync("Hello this is a Test from Use II - I \n VybzTech \n");
                await next();
                await context.Response.WriteAsync("Hello this is a Test from Use II - II \n VybzTech \n");
                app.Run(async context =>
                {
                    await context.Response.WriteAsync("Hello this is a Run Test from VybzTech. \n");
                });
            });
        }
    }
}
