using MetricsAgent.Implementation;
using MetricsAgent.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AutoMapper;
using MetricsAgent.Mapper;
using MetricsAgent.DAL.Interfaces;
using MetricsAgent.DAL;
using FluentMigrator.Runner;
using Quartz.Spi;
using MetricsAgent.Jobs;
using Quartz;
using Quartz.Impl;

namespace MetricsAgent
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MetricsAgent", Version = "v1" });
            });

            services.AddSingleton<ISqlSettingsProvider, SqlSettingsProvider>();

            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSingleton<IRepositoryCpuMetrics, CpuMetricsRepository>();
            services.AddSingleton<IRepositoryDotNetMetrics, DotNetMetricsRepository>();
            services.AddSingleton<IRepositoryHddMetrics, HddMetricsRepository>();
            services.AddSingleton<IRepositoryNetWorkMetrics, NetWorkRepository>();
            services.AddSingleton<IRepositoryRamMetrics, RamMetricsRepository>();

            services.AddFluentMigratorCore()
                .ConfigureRunner(mig => 
                mig.AddSQLite()
                .WithGlobalConnectionString(new SqlSettingsProvider().GetConnectionString())
                .ScanIn(typeof(Startup).Assembly).For.Migrations()
                ).AddLogging(lb => lb
                    .AddFluentMigratorConsole());

            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddSingleton<CpuMetricsJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(CpuMetricsJob),
                cronExpression: "0/5 * * * * ?"));
            services.AddSingleton<RamMetricsJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(RamMetricsJob),
                cronExpression: "0/5 * * * * ?"));
            services.AddSingleton<HddMetricsJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(HddMetricsJob),
                cronExpression: "0/5 * * * * ?"));
            services.AddSingleton<DotNetMetricsJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(DotNetMetricsJob),
                cronExpression: "0/5 * * * * ?"));
            services.AddSingleton<NetWorkMetricsJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(NetWorkMetricsJob),
                cronExpression: "0/5 * * * * ?"));
            services.AddHostedService<QuartzHostedService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMigrationRunner migrationRunner)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MetricsAgent v1"));
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
