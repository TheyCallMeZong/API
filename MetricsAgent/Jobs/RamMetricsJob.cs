using MetricsAgent.Interface;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using MetricsAgent.Data;

namespace MetricsAgent.Jobs
{
    public class RamMetricsJob : IJob
    {
        private readonly IServiceProvider _provider;
        private readonly IRepositoryRamMetrics _repository;
        private readonly PerformanceCounter _counter;

        public RamMetricsJob(IServiceProvider provider)
        {
            _provider = provider;
            _repository = _provider.GetService<IRepositoryRamMetrics>();
            _counter = new PerformanceCounter("Memory", "Available MBytes");
        }

        public Task Execute(IJobExecutionContext context)
        {
            double ramAvailable = Convert.ToInt32(_counter.NextValue());
            var time = DateTimeOffset.UtcNow;
            _repository.Create(new RamMetrics()
            {
                Time = time,
                Available = ramAvailable
            });
            return Task.CompletedTask;
        }
    }
}
