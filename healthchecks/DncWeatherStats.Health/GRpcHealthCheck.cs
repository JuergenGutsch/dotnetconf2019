using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DncWeatherStats.Health
{
    public class GRpcHealthCheck : IHealthCheck
    {
        private string _host;

        public GRpcHealthCheck(string host)
        {
            _host = host;
        }

        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            try
            {
                using (var channel = GrpcChannel.ForAddress(_host))
                {
                    var client = new Weather.WeatherClient(channel);
                    var result = client.WeatherData(new WeatherRequest());

                    var healthCheckResultHealthy = result.WeatherData.Any();

                    if (healthCheckResultHealthy)
                    {
                        return Task.FromResult(
                            HealthCheckResult.Healthy("A healthy result."));
                    }
                }

                return Task.FromResult(
                    HealthCheckResult.Unhealthy("An unhealthy result."));
            }
            catch (Exception ex)
            {
                return Task.FromResult(
                    HealthCheckResult.Unhealthy(ex.Message));
            }
        }
    }
}
