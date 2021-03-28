using MetricsManager;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class MetricsManagerTests
    {
        private NetWorkMetricsControllerByAgent netWorkMetricsController;
        private DotNetMetricsControllerByAgent dotNetMetricsController;
        private CpuMetricsControllerByAgent controller;
        private HddMetricsControllerByAgent hddMetricsController;
        private RamMetricsControllerByAgent ramMetricsController;
        public MetricsManagerTests()
        {
            ramMetricsController = new RamMetricsControllerByAgent();
            netWorkMetricsController = new NetWorkMetricsControllerByAgent();
            controller = new CpuMetricsControllerByAgent();
            dotNetMetricsController = new DotNetMetricsControllerByAgent();
            hddMetricsController = new HddMetricsControllerByAgent();
        }
        int agentId = 1;
        TimeSpan fromTime = TimeSpan.FromSeconds(0);
        TimeSpan toTime = TimeSpan.FromSeconds(100);
        #region
        [Fact]
        public void GetMetricsCpuByPercentile_ReturnOk()
        {
            var percentile = Percentile.P95;
            _ = Assert.IsAssignableFrom<IActionResult>(controller.GetMetricsByPercentile(agentId, fromTime, toTime, percentile));
        }

        [Fact]
        public void GetMetricsCpu_ReturnOk()
        {
            _ = Assert.IsAssignableFrom<IActionResult>(controller.GetMetrics(agentId, fromTime, toTime));
        }

        [Fact]
        public void GetMetricsFromAllCluster_ReurnOk()
        {
            _ = Assert.IsAssignableFrom<IActionResult>(controller.GetMetricsFromAllCluster(fromTime, toTime));
        }

        [Fact]
        public void GetMetricsByPercentileFromAllCluster_ReturnOk()
        {
            _ = Assert.IsAssignableFrom<IActionResult>(controller.GetMetricsByPercentileFromAllCluster(fromTime, toTime,
                Percentile.P95));
        }
        #endregion
        #region
        [Fact]
        public void GetErrors_ReturnOk()
        {
            _ = Assert.IsAssignableFrom<IActionResult>(dotNetMetricsController.GetErrors(agentId, fromTime, toTime));
        }

        [Fact]
        public void GetMetricsFromAllClusterInDotNet_ReurnOk()
        {
            _ = Assert.IsAssignableFrom<IActionResult>(dotNetMetricsController.GetMetricsFromAllCluster(fromTime, toTime));
        }

        [Fact]
        public void GetMetricsByPercentileFromAllClusterInDotNet_ReturnOk()
        {
            _ = Assert.IsAssignableFrom<IActionResult>(dotNetMetricsController.GetMetricsByPercentileFromAllCluster(fromTime, toTime,
                Percentile.P95));
        }
        #endregion
        #region
        [Fact]
        public void GetFreeSpaceSize_ReturnOk()
        {
            _ = Assert.IsAssignableFrom<IActionResult>(hddMetricsController.GetFreeSpaceSize(agentId));
        }

        [Fact]
        public void GetMetricsFromAllClusterInHdd_ReurnOk()
        {
            _ = Assert.IsAssignableFrom<IActionResult>(hddMetricsController.GetMetricsFromAllCluster(fromTime, toTime));
        }

        [Fact]
        public void GetMetricsByPercentileFromAllClusterInHdd_ReturnOk()
        {
            _ = Assert.IsAssignableFrom<IActionResult>(hddMetricsController.GetMetricsByPercentileFromAllCluster(fromTime, toTime,
                Percentile.P95));
        }
        #endregion
        #region
        [Fact]
        public void GetMetricsInNetWork_ReturnOk()
        {
            _ = Assert.IsAssignableFrom<IActionResult>(netWorkMetricsController.GetMetrics(agentId, fromTime, toTime));
        }

        [Fact]
        public void GetMetricsFromAllClusterInNetWork_ReurnOk()
        {
            _ = Assert.IsAssignableFrom<IActionResult>(netWorkMetricsController.GetMetricsFromAllCluster(fromTime, toTime));
        }

        [Fact]
        public void GetMetricsByPercentileFromAllClusterInNetWork_ReturnOk()
        {
            _ = Assert.IsAssignableFrom<IActionResult>(netWorkMetricsController.GetMetricsByPercentileFromAllCluster(fromTime, toTime,
                Percentile.P95));
        }
        #endregion
        #region
        [Fact]
        public void GetFreeSpaceSizeInRam_ReturnOk()
        {
            _ = Assert.IsAssignableFrom<IActionResult>(ramMetricsController.GetFreeSpaceSize(agentId));
        }

        [Fact]
        public void GetMetricsFromAllClusterInRam_ReurnOk()
        {
            _ = Assert.IsAssignableFrom<IActionResult>(ramMetricsController.GetMetricsFromAllCluster(fromTime, toTime));
        }

        [Fact]
        public void GetMetricsByPercentileFromAllClusterInRam_ReturnOk()
        {
            _ = Assert.IsAssignableFrom<IActionResult>(ramMetricsController.GetMetricsByPercentileFromAllCluster(fromTime, toTime,
                Percentile.P95));
        }
        #endregion
    }
}
