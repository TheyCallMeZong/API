using MetricsAgent.Interface;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MetricsAgent.Data;

namespace MetricsAgent.Jobs
{
    public class HddMetricsJob : IJob
    {
        private readonly IServiceProvider _provider;
        private readonly IRepositoryHddMetrics _repository;
        private readonly PerformanceCounter _counter;

        public HddMetricsJob(IServiceProvider provider)
        {
            _provider = provider;
            _repository = _provider.GetService<IRepositoryHddMetrics>();
            _counter = new PerformanceCounter("LogicalDisk", "Free Megabytes", "C:");
        }

        public Task Execute(IJobExecutionContext context)
        {
            double hddFreeSpace = _counter.NextValue() / 1024 / 1024;
            var time = DateTimeOffset.UtcNow;
            _repository.Create(new HddMetrics()
            {
                Time = time,
                FreeSize = hddFreeSpace
            });
            return Task.CompletedTask;
        }
    }
}
