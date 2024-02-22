using CA_Microservices_DotNet.Domain.Interfaces;
using CA_Microservices_DotNet.Domain.Interfaces.Services;
using CA_Microservices_DotNet.Common.Models;
using Microsoft.EntityFrameworkCore;
using CA_Microservices_DotNet.Domain.Entities;

namespace CA_Microservices_DotNet.Application.Services;

public class ReviewService : IReviewService
{
    private readonly IUnitOfWork _unitOfWork;

    public ReviewService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <inheritdoc/>
    public async Task AddReview(ReviewModel review, string userId, CancellationToken cancellationToken = default)
    {
        var book = await _unitOfWork.Books.FirstOrDefaultAsync(b => b.Id == review.BookId, cancellationToken)
            ?? throw new KeyNotFoundException();

        var reviewEntity = ToReview(review, userId);
        book.Reviews.Add(reviewEntity);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    #region Private Methods
    
    private static Review ToReview(ReviewModel source, string userId) =>
        new()
        {
            Description = source.Description,
            CreatedDate = DateTime.Now,
            Stars = source.Stars,
            BookId = source.BookId,
            UserId = userId,
        };

    #endregion

}
