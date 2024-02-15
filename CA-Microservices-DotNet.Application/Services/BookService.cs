using CA_Microservices_DotNet.Domain.Entities;
using CA_Microservices_DotNet.Domain.Interfaces.Repositories;
using CA_Microservices_DotNet.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;

namespace CA_Microservices_DotNet.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMemoryCache _cache;
        private readonly MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

        public BookService(IBookRepository bookService, IMemoryCache cache)
        {
            _bookRepository = bookService;
            _cache = cache;
        }

        public async Task<List<Book>> GetAllBooks(CancellationToken cancellationToken = default)
        {
            return await _bookRepository.GetAllBooks();
        }

        public async Task<Book?> GetBook(int id, CancellationToken cancellationToken = default)
        {
            if (_cache.TryGetValue(id, out Book data))
            {
                return data;
            }

            _cache.Set(id, data, cacheOptions);

            return await _bookRepository.GetBook(id, cancellationToken);
        }
    }
}
