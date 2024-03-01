using AutoMapper;
using CA_Microservices_DotNet.Common.Models;
using CA_Microservices_DotNet.Domain.Entities;
using CA_Microservices_DotNet.Domain.Interfaces;
using CA_Microservices_DotNet.Domain.Interfaces.Repositories;
using CA_Microservices_DotNet.Domain.Interfaces.Services;
using Microsoft.Extensions.Caching.Memory;

namespace CA_Microservices_DotNet.Application.Services;

public class BookService : IBookService
{
    private readonly IGenericRepository<Book> _genericRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    private readonly IMemoryCache _cache;
    private readonly MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
    private const string cacheKey = $"Collection.{nameof(Book)}";

    public BookService(IMemoryCache cache, 
        IGenericRepository<Book> genericRepo, 
        IUnitOfWork unitOfWork, 
        IMapper mapper)
    {
        _cache = cache;
        _genericRepo = genericRepo;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<List<BookModel>> GetAllBooks(CancellationToken cancellationToken = default)
    {
        if(_cache.TryGetValue(cacheKey, out List<Book>? cachedBooks))
        {
            return _mapper.Map<List<BookModel>>(cachedBooks);
        }

        var books = await _genericRepo.Get(includeProperties: ["Reviews"], cancellationToken: cancellationToken);
        _cache.Set(cacheKey, books);

        return _mapper.Map<List<BookModel>>(books);
    }

    /// <inheritdoc/>
    public async Task<Book?> GetBook(int id, CancellationToken cancellationToken = default)
    {
        if (_cache.TryGetValue(id, out Book? data))
        {
            return data;
        }

        var book = (await _genericRepo.Get(book => book.Id == id, ["Reviews"], cancellationToken)).First();
        _cache.Set(id, book, cacheOptions);

        return book;
    }
}
