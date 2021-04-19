using AutoMapper;
using FluentMigrator.Runner;
using MetricsManager.DAL;
using MetricsManager.DAL.Implementation;
using MetricsManager.DAL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "“рынтынтын", Version = "v1" });
            });

            services.AddSingleton<ICpuMetricsRepository, CpuMetricsRepository>();

            var configure = new MapperConfiguration(con => con.AddProfile(new MapperProfile()));
            var mapper = configure.CreateMapper();
            services.AddSingleton(mapper);

            services.AddFluentMigratorCore()
                .ConfigureRunner(mig 
                => mig.AddSQLite()
                .WithGlobalConnectionString(new SqlSettingsProvider().GetConnection()).
                ScanIn(typeof(Startup).Assembly).For.Migrations()
                ).AddLogging(lb => lb
                    .AddFluentMigratorConsole());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMigrationRunner migrationRunner)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ўо да ни шо v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            migrationRunner.MigrateUp();
        }
    }
}
