using CA_Microservices_DotNet.API.HealthCheck;
using CA_Microservices_DotNet.Application.Services;
using CA_Microservices_DotNet.Domain.Entities;
using CA_Microservices_DotNet.Domain.Interfaces;
using CA_Microservices_DotNet.Domain.Interfaces.Repositories;
using CA_Microservices_DotNet.Domain.Interfaces.Services;
using CA_Microservices_DotNet.Infrastructure;
using CA_Microservices_DotNet.Infrastructure.Repositories;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the IoC.
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IMemoryCacheService, MemoryCacheService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//Register GenericRepository of any type is required/requested.
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

//Add DBContext where the Identity tables are going to be created.
var connectionString = builder.Configuration.GetConnectionString("ca-microservices-sql-db");
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configure Logging with Serilog
builder.Host.UseSerilog((context, config) =>
    config.WriteTo.Console()
    .ReadFrom.Configuration(context.Configuration)
    .WriteTo.MSSqlServer(connectionString,
        sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions()
        {
            TableName = "Logs",
        })
    );

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

//Add AutoMapper to IoC and find Profiles in the current solution
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register IMemoryCache for D.I.
builder.Services.AddMemoryCache();

//Register custom health check
builder.Services.AddHealthChecks()
    .AddCheck<SampleHealthCheck>("Sample");

//Add Swagger bearer token authentication 
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthorization();

//Add the custom default Identity user and set the DBContext for Identity Framework.
builder.Services
    .AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<MyDbContext>();

var app = builder.Build();

//Maps the Identity Framework endpoints to the default identity 
app.MapIdentityApi<User>();

//Configures behavior of custom health check
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
    ResultStatusCodes = new Dictionary<HealthStatus, int>()
    {
        { HealthStatus.Healthy, 200 },
        { HealthStatus.Unhealthy, 500 },
        { HealthStatus.Degraded, 200 }
    },
    AllowCachingResponses = false
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //Run migrations only in DEVELOPMENT environment
    using var scope = app.Services.CreateScope();
    using var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    dbContext.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
