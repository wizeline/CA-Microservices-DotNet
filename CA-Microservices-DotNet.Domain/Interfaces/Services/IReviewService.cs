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
}
