using AutoMapper;
using CA_Microservices_DotNet.Common.Models;
using CA_Microservices_DotNet.Domain.Entities;
using CA_Microservices_DotNet.Domain.Interfaces;
using CA_Microservices_DotNet.Domain.Interfaces.Repositories;
using CA_Microservices_DotNet.Domain.Interfaces.Services;

namespace CA_Microservices_DotNet.Application.Services;

public class BookService : IBookService
{
    private readonly IGenericRepository<Book> _genericRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    private readonly IMemoryCacheService _cache;
    private readonly static TimeSpan _cacheExpiration = TimeSpan.FromMinutes(1);
    private const string cacheKey = $"Collection.{nameof(Book)}";

    public BookService(IMemoryCacheService cache, 
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
        //Check if value exists in cache
        if (_cache.TryGetValue(cacheKey, out List<Book>? cachedBooks))
        {
            return _mapper.Map<List<BookModel>>(cachedBooks);
        }

        //Get from database if does not exist value in cache
        var books = await _genericRepo.Get(includeProperties: ["Reviews"], cancellationToken: cancellationToken);

        //Store value in cache for the next call if any
        if(books.Count > 0)
            _ = _cache.Set(cacheKey, books, _cacheExpiration);

        return _mapper.Map<List<BookModel>>(books);
    }

    /// <inheritdoc/>
    public async Task<BookModel?> GetBook(int id, CancellationToken cancellationToken = default)
    {
        //Create a specific cache key for this book
        var bookCacheKey = $"{cacheKey}.{id}";

        //Check if value exist in cache
        if (_cache.TryGetValue(bookCacheKey, out Book? cachedBook))
        {
            return _mapper.Map<BookModel>(cachedBook);
        }

        //Get from database if does not exist value in cache
        var book = (await _genericRepo.Get(book => book.Id == id, ["Reviews"], cancellationToken)).First();

        //Store value in cache for the next call 
        _cache.Set(bookCacheKey, book, _cacheExpiration);

        return _mapper.Map<BookModel>(book);
    }
}
