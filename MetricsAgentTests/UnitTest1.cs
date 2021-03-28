using MetricsAgent;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class MetricsAhentTests
    {
        private NetWorkMetricsController netWorkMetricsController;
        private DotNetMetricsController dotNetMetricsController;
        private CpuMetricsController controller;
        private HddMetricsController hddMetricsController;
        private RamMetricsController ramMetricsController;
        public MetricsAhentTests()
        {
            ramMetricsController = new RamMetricsController();
            netWorkMetricsController = new NetWorkMetricsController();
            controller = new CpuMetricsController();
            dotNetMetricsController = new DotNetMetricsController();
            hddMetricsController = new HddMetricsController();
        }
        TimeSpan fromTime = TimeSpan.FromSeconds(0);
        TimeSpan toTime = TimeSpan.FromSeconds(100);
        #region
        [Fact]
        public void GetMetricsCpuByPercentile_ReturnOk()
        {
            var percentile = Percentile.P95;
            _ = Assert.IsAssignableFrom<IActionResult>(controller.GetMetricsByPercentile(fromTime, toTime, percentile));
        }

        [Fact]
        public void GetMetricsCpu_ReturnOk()
        {
            _ = Assert.IsAssignableFrom<IActionResult>(controller.GetMetrics(fromTime, toTime));
        }
        #endregion
        #region
        [Fact]
        public void GetErrors_ReturnOk()
        {
            _ = Assert.IsAssignableFrom<IActionResult>(dotNetMetricsController.GetErrors(fromTime, toTime));
        }

        #endregion
        #region
        [Fact]
        public void GetFreeSpaceSize_ReturnOk()
        {
            _ = Assert.IsAssignableFrom<IActionResult>(hddMetricsController.GetFreeSpaceSize());
        }
        #endregion
        #region
        [Fact]
        public void GetMetricsInNetWork_ReturnOk()
        {
            _ = Assert.IsAssignableFrom<IActionResult>(netWorkMetricsController.GetMetrics(fromTime, toTime));
        }
        #endregion
        #region
        [Fact]
        public void GetFreeSpaceSizeInRam_ReturnOk()
        {
            _ = Assert.IsAssignableFrom<IActionResult>(ramMetricsController.GetFreeSpaceSize());
        }
        #endregion
    }
}
