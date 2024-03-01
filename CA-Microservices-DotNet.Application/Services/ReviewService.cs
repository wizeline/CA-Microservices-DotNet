using CA_Microservices_DotNet.Domain.Interfaces;
using CA_Microservices_DotNet.Domain.Interfaces.Services;
using CA_Microservices_DotNet.Common.Models;
using Microsoft.EntityFrameworkCore;
using CA_Microservices_DotNet.Domain.Entities;
using CA_Microservices_DotNet.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Caching.Memory;
using AutoMapper;

namespace CA_Microservices_DotNet.Application.Services;

public class ReviewService : IReviewService
{
    private readonly IUnitOfWork _unitOfWork;
    private IGenericRepository<Review> _reviewRepository;
    private readonly IMemoryCache _memoryCache;
    private readonly IMapper _mapper;
    private const string cacheKey = $"Collection.{nameof(Review)}";

    public ReviewService(IUnitOfWork unitOfWork,
        IGenericRepository<Review> reviewRepository,
        IMemoryCache memoryCache,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _reviewRepository = reviewRepository;
        _memoryCache = memoryCache;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task AddReview(ReviewModel review, string userId, CancellationToken cancellationToken = default)
    {
        var book = await _unitOfWork.Books.FirstOrDefaultAsync(b => b.Id == review.BookId, cancellationToken)
            ?? throw new KeyNotFoundException();

        var reviewEntity = _mapper.Map<Review>(review);
        reviewEntity.UserId = userId;
        
        book.Reviews.Add(reviewEntity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<ReviewModel>> GetReviews(int bookId, CancellationToken cancellationToken = default)
    {
        if(_memoryCache.TryGetValue(bookId, out var cachedReviews))
        {
            return _mapper.Map<List<ReviewModel>>(cachedReviews);
        }

        var reviews = await _reviewRepository.Get(r => r.BookId == bookId, cancellationToken: cancellationToken);
        _memoryCache.Set(cacheKey, reviews);

        return _mapper.Map<List<ReviewModel>>(reviews);
    }

    /// <inheritdoc/>
    public async Task<ReviewModel> GetReview(int reviewId, CancellationToken cancellationToken = default)
    {
        var review = await _reviewRepository.GetById(reviewId, cancellationToken: cancellationToken);
        return _mapper.Map<ReviewModel>(review);
    }

    /// <inheritdoc/>
    public async Task<List<ReviewModel>> GetMyReviews(string userId, CancellationToken cancellationToken = default)
    {
        var myReviews = await _reviewRepository.Get(r => r.UserId == userId, cancellationToken: cancellationToken);

        return _mapper.Map<List<ReviewModel>>(myReviews);
    }
}
