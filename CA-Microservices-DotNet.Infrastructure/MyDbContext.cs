using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CA_Microservices_DotNet.Infrastructure
{
    public class MyDbContext(DbContextOptions<MyDbContext> options) : IdentityDbContext(options)
    {
    }
}
