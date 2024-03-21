using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Respawn;
using Respawn.Graph;

namespace CA_Microservices_DotNet.Infrastructure.Integration.Tests;

[SetUpFixture]
internal class Startup
{
    internal static IConfiguration Configuration { get; private set; } = default!;

    internal static MyDbContext DbContext { get; private set; } = default!;

    //Used by Respawner to know which tables is going to truncate, include yours as needed.
    internal static readonly Table[] TablesToTruncate = new Table[]
    {
        new ("Reviews"),
        new ("Books")
    };

    [OneTimeSetUp]
    public async Task OneTimeSetup()
    {
        //Reads the 'testsettings.json' and loads the configs.
        Configuration = BuildConfiguration();
        
        //Creates the DbContext instance for the seed data.
        DbContext = CreateDbContext();

        //Leaves the tables in a clean state  to ensure tests runs correctly
        await TruncateDatabaseAsync();
    }

    [OneTimeTearDown]
    public static async Task OneTimeTearDown()
    {
        //Clean all the records added by the tests.
        await TruncateDatabaseAsync();
    }

    /// <summary>
    /// Loads the tests configuration 
    /// </summary>
    /// <returns></returns>
    private static IConfiguration BuildConfiguration() =>
         new ConfigurationBuilder()
            .AddJsonFile("testsettings.json")
            .AddEnvironmentVariables()
            .Build();

    /// <summary>
    /// Create a new instance of MyDbContext
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private static MyDbContext CreateDbContext()
    {
        var connectionString = GetConnectionString()
            ?? throw new Exception("ConnectionString cannot be null");

        var dbContextOptions = new DbContextOptionsBuilder<MyDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        return new MyDbContext(dbContextOptions);
    }

    private static async Task TruncateDatabaseAsync()
    {
        var connectionString = GetConnectionString()
           ?? throw new Exception("ConnectionString cannot be null");

        var options = new RespawnerOptions()
        {
            //Tables to include at the truncate process
            TablesToInclude = TablesToTruncate
        };

        var respawner = await Respawner.CreateAsync(connectionString, options);
        
        //Performs the actual truncate to the database.
        await respawner.ResetAsync(connectionString);
    }

    /// <summary>
    /// Finds the connection string in the configuration.
    /// </summary>
    /// <returns></returns>
    private static string? GetConnectionString() => Configuration.GetConnectionString("localhost");
}
