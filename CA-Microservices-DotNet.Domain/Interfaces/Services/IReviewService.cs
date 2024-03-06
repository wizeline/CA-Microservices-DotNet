using CA_Microservices_DotNet.Common.Models;

namespace CA_Microservices_DotNet.Domain.Interfaces.Services;

public interface IReviewService
{
    /// <summary>
    /// Adds a review to the book by its id.
    /// </summary>
    /// <param name="review"></param>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddReview(ReviewModel review, string userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets all the reviews of a book by its id.
    /// </summary>
    /// <param name="bookId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<ReviewModel>> GetReviews(int bookId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a review by its id.
    /// </summary>
    /// <param name="reviewId"></param>
    /// <returns></returns>
    Task<ReviewModel> GetReview(int reviewId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get reviews created by the userId.
    /// </summary>
    /// <param name="userId">Owner of the reviews</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<ReviewModel>> GetMyReviews(string userId, CancellationToken cancellationToken = default);
}

