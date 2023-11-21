using CA_Microservices_DotNet.Domain.Entities;
using CA_Microservices_DotNet.Domain.Interfaces.Repositories;

namespace CA_Microservices_DotNet.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books = [];

        public BookRepository()
        {
            _books = new List<Book>()
            {
                new()
                {
                    Id = 1,
                    Name = "The Lord of the Rings",
                    Description = "This is a description of book 2.",
                    AuthorId = 1,
                    Author = new Author()
                    {
                        Id = 1,
                        Name = "J.R.R. Tolkien",
                    }
                },
                new()
                {
                    Id = 2,
                    Name = "Harry Potter and the Sorcerer's Stone",
                    Description = "This is a description of book 2.",
                    AuthorId = 2,
                    Author = new Author()
                    {
                        Id = 2,
                        Name = "J.K. Rowling",
                    }
                },
                new()
                {
                    Id = 3,
                    Name = "Pride and Prejudice",
                    Description = "This is a description of book 3.",
                    AuthorId = 3,
                    Author = new Author()
                    {
                        Id = 3,
                        Name = "Jane Austen",
                    }
                }
            };
        }

        /// <inheritdoc/>
        public Task<List<Book>> GetAllBooks()
        {
            return Task.FromResult(_books);
        }

        /// <inheritdoc/>
        public Task<Book> GetBook(int id)
        {
            var book = _books.Find(b => b.Id == id) 
                ?? new Book();

            return Task.FromResult(book);
        }
    }
}
