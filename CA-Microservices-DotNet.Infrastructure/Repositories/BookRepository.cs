using CA_Microservices_DotNet.Domain.Entities;
using CA_Microservices_DotNet.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CA_Microservices_DotNet.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books = [];
        private readonly MyDbContext _dbContext;

        public BookRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public Task<List<Book>> GetAllBooks()
        {
            return _dbContext.Books.ToListAsync();
        }

        /// <inheritdoc/>
        public Task<Book?> GetBook(int id, CancellationToken cancellationToken = default)
        {
            return _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
        }
    }
}
