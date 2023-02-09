
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleToWeb
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddTransient<CustomMiddleware>();

      /*
      services.TryAddTransient<IProductRepository, TestRepository>();
      services.TryAddTransient<IProductRepository, ProductRepository>();
  */
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      //SHOW DEVELOPER ERROR IF IN DEVELOPMENT MODE
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      // ROUTING MIDDLEWARE
      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      /*
      //SOME CODE TO SHOW ORDER OF EXECUTION
      // app.Use(async (context, next) =>
      // {
      //   await context.Response.WriteAsync("Hello this is a Test from Use - I \n");
      //   await next();
      //   await context.Response.WriteAsync("Hello this is a Test from Use - II \n");
      // });
*/

      // OUR FIRST CUSTOM MIDDLEWARE
      app.UseMiddleware<CustomMiddleware>();

      // MAPPING OUR OWN LINKS
      app.Map("/url", CustomCode);

      app.Use(async (context, next) =>
      {
        await context.Response.WriteAsync("Hello this is a Test from Use II - I \n");
        await context.Response.WriteAsync("Hello this is a Test from Use II - II \n");
        await next();
      });

      app.Use(async (context, next) =>
      {
        await next();
        await context.Response.WriteAsync("Request complete \n");
      });

      app.Run(async context =>
        {
          await context.Response.WriteAsync("Hello this is a Run Test \n");
        });


    }

    private void CustomCode(IApplicationBuilder app) =>
      app.Use(async (context, next) =>
      {
        await context.Response.WriteAsync("Some new Vybz ... \n");
        await next();
      });
  }
}