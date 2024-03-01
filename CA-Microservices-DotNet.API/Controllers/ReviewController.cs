using CA_Microservices_DotNet.Common.Models;
using CA_Microservices_DotNet.Domain.Interfaces.Services;
using CA_Microservices_DotNet.DTO.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CA_Microservices_DotNet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ReviewController : ControllerBase
{
    private IReviewService _reviewService;
    //TODO: Add Login to All services
    //TODO: Add exception handling
    //TODO: Add integration test project

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpPost]
    public async Task<IActionResult> AddReview(ReviewModel reviewModel, CancellationToken cancellationToken)
    {
        if(ModelState.IsValid)
        {
            var userId = User.GetUserId();

            await _reviewService.AddReview(reviewModel, userId, cancellationToken);

            return Created();
        }

        return BadRequest(ModelState.ValidationState);
    }

    [HttpGet("{bookId:int}")]
    public async Task<IActionResult> GetReviews(int bookId, CancellationToken cancellationToken)
    {
        var reviews = await _reviewService.GetReviews(bookId, cancellationToken);
        return Ok(reviews);
    }
}
