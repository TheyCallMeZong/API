using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Jobs
{
    public class CpuMetriscJob : IJob
    {
        public CpuMetriscJob()
        {

        }
        public Task Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
