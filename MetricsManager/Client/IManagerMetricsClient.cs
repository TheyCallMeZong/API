using MetricsManager.Requests;
using MetricsManager.Responses;

namespace MetricsManager.Client
{
    public interface IManagerMetricsClient
    {
        AllCpuMetricsResponses GetAllCpuMetrics(CpuMetricsRequest cpuMetrics);
        AllDotNetMetricsResponse GetAllDotNetMetrics(DotNetMetricsRequest dotNetMetrics);
        AllHddMetricsResponse GetAllHddMetrics(HddMetricsRequest hddMetrics);
        AllNetWorkMetricsResponse GetAllNetWorkMetrics(NetWorkMetricsRequest netWorkMetrics);
        AllRamMetricsResponse GetAllRamMetrics(RamMetricsRequest ramMetrics);
    }
}
