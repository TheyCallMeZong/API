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
    public class NetWorkMetricsJob : IJob
    {
        private readonly IServiceProvider _provider;
        private readonly IRepositoryNetWorkMetrics _repository;
        private readonly PerformanceCounter _counter;

        public NetWorkMetricsJob(IServiceProvider provider)
        {
            _provider = provider;
            _repository = _provider.GetService<IRepositoryNetWorkMetrics>();
            _counter = new PerformanceCounter("Network Interface", "Bytes Received/sec", "Intel[R] Wireless-AC 9462");
        }

        public Task Execute(IJobExecutionContext context)
        {
            int bytesRecived = Convert.ToInt32(_counter.NextValue());
            var time = DateTimeOffset.UtcNow;
            _repository.Create(new NetWorkMetrics()
            {
                Time = time,
                Value = bytesRecived
            });
            return Task.CompletedTask;
        }
    }
}
