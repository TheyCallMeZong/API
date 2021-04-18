using MetricsAgent.Data;
using MetricsAgent.Interface;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Runtime.Versioning;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class CpuMetricsJob : IJob
    {
        private readonly IRepositoryCpuMetrics _repository;
        private readonly PerformanceCounter performanceCounter;

        [SupportedOSPlatform("windows")]
        public CpuMetricsJob(IServiceProvider provider)
        {
            _repository = provider.GetService<IRepositoryCpuMetrics>();
            performanceCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        }

        public Task Execute(IJobExecutionContext context)
        {
            int cpuUsageInPercents = 0;
            if (OperatingSystem.IsWindows())
            {
                cpuUsageInPercents = Convert.ToInt32(performanceCounter.NextValue());
            }
            var time = DateTimeOffset.UtcNow;
            _repository.Create(new CpuMetrics()
            {
                Time = time,
                Value = cpuUsageInPercents
            });
            return Task.CompletedTask;
        }
    }
}
