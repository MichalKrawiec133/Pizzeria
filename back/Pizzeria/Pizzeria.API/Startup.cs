using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pizzeria.Api.HealthChecks;
using Pizzeria.Data.Sql;
using Pizzeria.Data.Sql.Migrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace Pizzeria.Api
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        private const string MySqlHealthCheckName = "mysql";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PizzeriaDbContext>(options => options
                .UseMySQL(Configuration.GetConnectionString("PizzeriaDbContext")));
            services.AddCors();
            services.AddTransient<DatabaseSeed>();
            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            //dodanie health checku i konfiguracja health checku dla MySqla
            services.AddHealthChecks()
                .AddMySql(
                    Configuration.GetConnectionString("PizzeriaDbServer"),
                    4,
                    10,
                    MySqlHealthCheckName);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.WithOrigins("http://localhost:4200")
                .AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //wystawienie pod adresem /healthy stanu healthchecków
            app.UseHealthChecks("/healthy");

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<PizzeriaDbContext>();
                var databaseSeed = serviceScope.ServiceProvider.GetRequiredService<DatabaseSeed>();

                //sprawdzenie czy health check się powiódł
                var healthCheck = serviceScope.ServiceProvider.GetRequiredService<HealthCheckService>();
                if (healthCheck.CheckHealthAsync().Result?.Entries[MySqlHealthCheckName].Status
                    == HealthCheckResult.Healthy().Status)
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                   databaseSeed.Seed();
                }
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
