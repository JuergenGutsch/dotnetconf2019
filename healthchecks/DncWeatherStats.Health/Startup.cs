using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using DncWeatherStats.Common;
using System;

namespace DncWeatherStats.Health
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlite(
                        Configuration["ConnectionStrings:DefaultConnection"]);
                });
            services.AddHealthChecks()
                .AddCheck("Foo", () =>
                    HealthCheckResult.Healthy("Foo is OK!"), tags: new[] { "foo_tag" })
                .AddDbContextCheck<ApplicationDbContext>("ApplicationDbContext", null, new[] { "database" }, null)
                .AddUrlGroup(new Uri("http://station1/api/ping"), "Ping Station Bremerton", null, new[] { "stations", "Bremerton" })
                .AddUrlGroup(new Uri("http://station2/api/ping"), "Ping Station Cedar Lake", null, new[] { "stations", "CedarLake" })
                .AddUrlGroup(new Uri("http://station3/api/ping"), "Ping Station Kent", null, new[] { "stations", "Kent" })
                .AddUrlGroup(new Uri("http://station4/api/ping"), "Ping Station Monroe", null, new[] { "stations", "Monroe" })
                .AddCheck("Data Station Bremerton", new RestHealthCheck("http://station1"), null, new[] { "stations", "Bremerton" })
                .AddCheck("Data Station Cedar Lake", new RestHealthCheck("http://station2"), null, new[] { "stations", "CedarLake" })
                .AddCheck("Data Station Kent", new RestHealthCheck("http://station3"), null, new[] { "stations", "Kent" })
                .AddCheck("Data Station Monroe", new RestHealthCheck("http://station4"), null, new[] { "stations", "Monroe" });

            services.AddHealthChecksUI();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapHealthChecks("/healthchecks", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });

            app.UseHealthChecksUI();
        }
    }
}
