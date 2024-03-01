using CA_Microservices_DotNet.Infrastructure;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CA_Microservices_DotNet.API.HealthCheck;

public class SampleHealthCheck : IHealthCheck
{
    private readonly MyDbContext _dbContext;

    public SampleHealthCheck(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        bool isHealthy = _dbContext.Database.CanConnect();

        if (isHealthy)
        {
            return await Task.FromResult(
                HealthCheckResult.Healthy("Microservice is healthy."));
        }

        return await Task.FromResult(
            new HealthCheckResult(
                context.Registration.FailureStatus, "Microservice is unhealthy."));
    }
}
