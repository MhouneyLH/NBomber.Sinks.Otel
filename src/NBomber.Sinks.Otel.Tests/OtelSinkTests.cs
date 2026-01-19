using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using NBomber.Contracts;
using NBomber.Contracts.Stats;
using NBomber.Sinks.Otel;

namespace NBomber.Sinks.Prometheus.Example.Tests
{
    public class OtelSinkTests
    {
        [Fact]
        public async Task Init_ShouldConfigureMeterProvider()
        {
            // Arrange
            var config = new OtelSinkConfig { OtlpExportEndpoint = "http://localhost:4317" };
            var contextMock = new Mock<IBaseContext>();
            var infraConfigMock = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();
            var sink = new OtelSink(config);

            // Act
            await sink.Init(contextMock.Object, infraConfigMock.Object);

            // Assert
            // No exception means success (for this simple test)
        }

        [Fact]
        public async Task SaveRealtimeMetrics_ShouldNotThrow_WhenCalledWithEmptyMetrics()
        {
            // Arrange
            var sink = new OtelSink();
            var metrics = new MetricStats
            {
                Counters = Array.Empty<CounterStats>(),
                Gauges = Array.Empty<GaugeStats>()
            };

            // Act & Assert
            await sink.SaveRealtimeMetrics(metrics);
        }

        [Fact]
        public async Task SaveScenarioStats_ShouldNotThrow_WhenCalledWithEmptyStats()
        {
            // Arrange
            var sink = new OtelSink();
            var stats = Array.Empty<ScenarioStats>();

            // Act & Assert
            await sink.SaveRealtimeStats(stats);
        }
    }
}
