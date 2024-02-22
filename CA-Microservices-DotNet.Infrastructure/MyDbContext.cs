using CA_Microservices_DotNet.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CA_Microservices_DotNet.Infrastructure
{
    public class MyDbContext(DbContextOptions<MyDbContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<User> AppUsers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity => entity.ToTable("AppUsers"));

            builder.Entity<User>()
                .Property(u => u.FirstName)
                .HasDefaultValue("");
            
            builder.Entity<User>()
                .Property(u => u.LastName)
                .HasDefaultValue("");

            builder.Entity<User>()
                .Property(u => u.SecondLastName)
                .HasDefaultValue("");

            builder.Entity<User>()
                .Property(u => u.Phone)
                .HasDefaultValue("");

            builder.Entity<Book>()
                .HasData(new List<Book>()
                {
                    new()
                    {
                        Id = 1,
                        Name = "The Lord of the Rings",
                        Description = "This is a description of book 2.",
                        Author = "J.R.R. Tolkien"

                    },
                    new()
                    {
                        Id = 2,
                        Name = "Harry Potter and the Sorcerer's Stone",
                        Description = "This is a description of book 2.",
                        Author = "J.K. Rowling"
                    },
                    new()
                    {
                        Id = 3,
                        Name = "Pride and Prejudice",
                        Description = "This is a description of book 3.",
                        Author = "Jane Austen"
                    }
                });

            base.OnModelCreating(builder);
        }
    }
}
