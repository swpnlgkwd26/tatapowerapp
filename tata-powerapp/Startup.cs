using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tata_powerapp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Middleware :  Code
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("First Middleware");
                await next.Invoke();
            });

            // Circuit Breaker :  Next Middleware will not be called.
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Broken   the Execution");
            //});
            // Middleware2
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Second Middleware");
                await next.Invoke();
            });
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
