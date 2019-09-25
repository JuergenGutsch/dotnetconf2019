using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DncWeatherStats.Health
{
    public class RestHealthCheck : IHealthCheck
    {
        private Uri _url;

        public RestHealthCheck(string url)
        {
            _url = new Uri(url);
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _url;
                using (var result = await client.GetAsync("/WeatherData"))
                {
                    var healthCheckResultHealthy = result.IsSuccessStatusCode;

                    if (healthCheckResultHealthy)
                    {
                        return HealthCheckResult.Healthy("We get data");
                    }
                }
            }

            return HealthCheckResult.Unhealthy("We don't get any data.");
        }
    }
}
