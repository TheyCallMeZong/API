using MetricsAgent;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using MetricsCommon;
using Moq;
using Microsoft.Extensions.Logging;
using MetricsAgent.Interface;
using MetricsAgent.Data;

namespace MetricsManagerTests
{
    public class MetricsAhentTests
    {
        #region
        private NetWorkMetricsController netWorkMetricsController;
        private Mock<IRepositoryNetWorkMetrics> mockNetWork;
        private Mock<ILogger<NetWorkMetricsController>> mockLoggingNetWork; 
        private DotNetMetricsController dotNetMetricsController;
        private Mock<IRepositoryDotNetMetrics> mockDotNetMock;
        private Mock<ILogger<DotNetMetricsController>> mockLoggingDotNet;
        private CpuMetricsController controller;
        private Mock<IRepositoryCpuMetrics> mockCpuMetrcs;
        private Mock<ILogger<CpuMetricsController>> mockLoggingCpuMetrics;
        private HddMetricsController hddMetricsController;
        private Mock<IRepositoryHddMetrics> mockHddMetrics;
        private Mock<ILogger<HddMetricsController>> mockLoggingHddMetrics;
        private RamMetricsController ramMetricsController;
        private Mock<IRepositoryRamMetrics> mockRamMetrics;
        private Mock<ILogger<RamMetricsController>> mockLoggingRamMetrics;
        #endregion
        public MetricsAhentTests()
        {
            mockNetWork = new Mock<IRepositoryNetWorkMetrics>();
            mockLoggingNetWork = new Mock<ILogger<NetWorkMetricsController>>();
            netWorkMetricsController = new NetWorkMetricsController(mockLoggingNetWork.Object, mockNetWork.Object);
            mockDotNetMock = new Mock<IRepositoryDotNetMetrics>();
            mockLoggingDotNet = new Mock<ILogger<DotNetMetricsController>>();
            dotNetMetricsController = new DotNetMetricsController(mockLoggingDotNet.Object, mockDotNetMock.Object);
            mockCpuMetrcs = new Mock<IRepositoryCpuMetrics>();
            mockLoggingCpuMetrics = new Mock<ILogger<CpuMetricsController>>();
            controller = new CpuMetricsController(mockLoggingCpuMetrics.Object, mockCpuMetrcs.Object);
            mockHddMetrics = new Mock<IRepositoryHddMetrics>();
            mockLoggingHddMetrics = new Mock<ILogger<HddMetricsController>>();
            hddMetricsController = new HddMetricsController(mockLoggingHddMetrics.Object, mockHddMetrics.Object);
            mockRamMetrics = new Mock<IRepositoryRamMetrics>();
            mockLoggingRamMetrics = new Mock<ILogger<RamMetricsController>>();
            ramMetricsController = new RamMetricsController(mockLoggingRamMetrics.Object, mockRamMetrics.Object);
        }
        TimeSpan fromTime = TimeSpan.FromSeconds(0);
        TimeSpan toTime = TimeSpan.FromSeconds(100);
        Percentile percentile = Percentile.P95;

        #region
        [Fact]
        public void GetMetricsCpuByPercentile_ReturnOk()
        {
            mockCpuMetrcs.Setup(r => r.Create(It.IsAny<CpuMetrics>())).Verifiable(); 
            mockCpuMetrcs.Verify(repository => repository.Create(It.IsAny<CpuMetrics>()), Times.AtMostOnce());

        }

        [Fact]
        public void GetMetricsCpu_ReturnOk()
        {
            mockCpuMetrcs.Setup(r => r.Create(It.IsAny<CpuMetrics>())).Verifiable();
            mockCpuMetrcs.Verify(repository => repository.Create(It.IsAny<CpuMetrics>()), Times.AtMostOnce());
        }
        #endregion
        #region
        [Fact]
        public void GetErrors_ReturnOk()
        {
            mockDotNetMock.Setup(r => r.Create(It.IsAny<DotNetMetrics>())).Verifiable();
            mockDotNetMock.Verify(repository => repository.Create(It.IsAny<DotNetMetrics>()), Times.AtMostOnce());
        }

        #endregion
        #region
        [Fact]
        public void GetFreeSpaceSize_ReturnOk()
        {
            mockHddMetrics.Setup(r => r.Create(It.IsAny<HddMetrics>())).Verifiable();
            mockHddMetrics.Verify(r => r.Create(It.IsAny<HddMetrics>()), Times.AtLeastOnce());
        }
        #endregion
        #region
        [Fact]
        public void GetMetricsInNetWork_ReturnOk()
        {
            mockNetWork.Setup(r => r.Create(It.IsAny<NetWorkMetrics>())).Verifiable();
            mockNetWork.Verify(repository => repository.Create(It.IsAny<NetWorkMetrics>()), Times.AtMostOnce());
        }
        #endregion
        #region
        [Fact]
        public void GetFreeSpaceSizeInRam_ReturnOk()
        {
            mockRamMetrics.Setup(r => r.Create(It.IsAny<RamMetrics>())).Verifiable();
            mockRamMetrics.Verify(r => r.Create(It.IsAny<RamMetrics>()), Times.AtLeastOnce());
        }
        #endregion
    }
}
