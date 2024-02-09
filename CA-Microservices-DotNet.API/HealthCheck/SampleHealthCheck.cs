using CA_Microservices_DotNet.Domain.Interfaces.Services;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CA_Microservices_DotNet.API.HealthCheck
{
    public class SampleHealthCheck : IHealthCheck
    {
        private readonly IConfiguration _config;

        public SampleHealthCheck(IConfiguration config)
        {
            _config = config;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var isHealthy = true;

            try
            {
                var connectionString = _config["ConnectionStrings:DefaultConnection"];
                using var connection = new SqlConnection(connectionString);
                await connection.OpenAsync(cancellationToken);
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT 1;";
                    await command.ExecuteScalarAsync(cancellationToken);
                }
            }
            catch
            {
                isHealthy = false;
            }

            if (isHealthy)
            {
                return await Task.FromResult(
                    HealthCheckResult.Healthy("A healthy result."));
            }

            return await Task.FromResult(
                new HealthCheckResult(
                    context.Registration.FailureStatus, "An unhealthy result."));
        }
    }
}
