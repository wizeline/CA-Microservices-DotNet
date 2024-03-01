using CA_Microservices_DotNet.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CA_Microservices_DotNet.Infrastructure;

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
                new() { Id = 1, Name = "The Lord of the Rings", Description = "This is a description of book 2.", Author = "J.R.R. Tolkien" },
                new() { Id = 2, Name = "Harry Potter and the Sorcerer's Stone", Description = "This is a description of book 2.", Author = "J.K. Rowling" },
                new() { Id = 3, Name = "Pride and Prejudice", Description = "This is a description of book 3.", Author = "Jane Austen" },
                new() { Id = 4, Name = "To Kill a Mockingbird", Description = "A timeless story about racial prejudice in the Deep South", Author = "Harper Lee" },
                new() { Id = 5, Name = "The Hitchhiker's Guide to the Galaxy", Description = "A comic science fiction series by Douglas Adams", Author = "Douglas Adams" },
                new() { Id = 6, Name = "One Hundred Years of Solitude", Description = "An epic novel of the Buendía family and their rise and fall", Author = "Gabriel García Márquez" },
                new() { Id = 7, Name = "The Great Gatsby", Description = "A novel about the Jazz Age and the American Dream", Author = "F. Scott Fitzgerald" },
                new() { Id = 8, Name = "Frankenstein", Description = "A gothic novel about the consequences of scientific ambition", Author = "Mary Shelley" },
                new() { Id = 9, Name = "1984", Description = "A dystopian novel about a totalitarian state", Author = "George Orwell" },
                new() { Id = 10, Name = "The Catcher in the Rye", Description = "A novel about a young man's alienation from society", Author = "J. D. Salinger" },
                new() { Id = 11, Name = "The God of Small Things", Description = "A novel about forbidden love and family secrets", Author = "Arundhati Roy" },
                new() { Id = 12, Name = "Invisible Man", Description = "A novel about an African-American man's search for identity", Author = "Ralph Ellison" },
                new() { Id = 13, Name = "Beloved", Description = "A novel about the psychological and emotional effects of slavery", Author = "Toni Morrison" },
                new() { Id = 14, Name = "Things Fall Apart", Description = "A novel about the clash of cultures between traditional and colonial societies", Author = "Chinua Achebe" },
                new() { Id = 15, Name = "The Book Thief", Description = "A novel set in Nazi Germany about a young girl who steals books", Author = "Markus Zusak" },
            });

        builder.Entity<Book>()
            .HasMany(b => b.Reviews)
            .WithOne(b => b.Book)
            .HasForeignKey(b => b.BookId);

        base.OnModelCreating(builder);
    }
}
