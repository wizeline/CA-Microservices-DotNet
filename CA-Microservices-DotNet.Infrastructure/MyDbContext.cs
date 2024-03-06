using CA_Microservices_DotNet.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CA_Microservices_DotNet.Infrastructure;

public class MyDbContext(DbContextOptions<MyDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<User> AppUsers { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Log> Logs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //This line scans all classes that inherits from IEntityTypeConfiguration
        //and run the Configure() Method to register its configuration
        //Each entity should have its on configuration 
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
