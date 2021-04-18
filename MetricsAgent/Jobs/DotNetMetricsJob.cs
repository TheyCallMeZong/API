using MetricsAgent.Interface;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MetricsAgent.Data;
using System.Runtime.Versioning;

namespace MetricsAgent.Jobs
{
    public class DotNetMetricsJob : IJob
    {
        private readonly IServiceProvider _provider;
        private readonly IRepositoryDotNetMetrics _repository;
        private readonly PerformanceCounter _counter;

        [SupportedOSPlatform("windows")]
        public DotNetMetricsJob(IServiceProvider provider)
        {
            _provider = provider;
            _repository = _provider.GetService<IRepositoryDotNetMetrics>();
            _counter = new PerformanceCounter(".NET CLR Memory", "# Bytes in all Heaps", "_Global_");
        }
        [SupportedOSPlatform("windows")]
        public Task Execute(IJobExecutionContext context)
        {
            int value = Convert.ToInt32(_counter.NextValue());
            var time = DateTimeOffset.UtcNow;
            _repository.Create(new DotNetMetrics()
            {
                Time = time,
                Value = value
            });
            return Task.CompletedTask;
        }
    }
}
