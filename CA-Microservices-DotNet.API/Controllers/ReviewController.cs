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
    private readonly IReviewService _reviewService;
    private readonly ILogger<ReviewController> _logger;

    public ReviewController(IReviewService reviewService, ILogger<ReviewController> logger)
    {
        _reviewService = reviewService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> AddReview(ReviewModel reviewModel, CancellationToken cancellationToken)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var userId = User.GetUserId();
                if (userId is null)
                {
                    _logger.LogError("Unable to find userId in the request");
                    return BadRequest("UserId not found");
                }

                await _reviewService.AddReview(reviewModel, userId, cancellationToken);

                return Ok();
            }

            return BadRequest(ModelState.ValidationState);
        }
        catch (Exception ex)
        {
            _logger.LogError("There was an error: {message}, {exception}", ex.Message, ex);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
       
    }

    [HttpGet("{bookId:int}")]
    public async Task<IActionResult> GetReviews(int bookId, CancellationToken cancellationToken)
    {
        try
        {
            var reviews = await _reviewService.GetReviews(bookId, cancellationToken);
            return Ok(reviews);
        }
        catch (Exception ex)
        {
            _logger.LogError("There was an error: {message}, {exception}", ex.Message, ex);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("mine")]
    public async Task<ActionResult<List<ReviewModel>>> GetMyReviews(CancellationToken cancellationToken)
    {
        try
        {
            var userId = User.GetUserId();
            if (userId is null)
            {
                _logger.LogError("Unable to find userId in the request");
                return BadRequest("UserId not found");
            }

            var reviews = await _reviewService.GetMyReviews(userId, cancellationToken);
            return Ok(reviews);
        }
        catch (Exception ex)
        {
            _logger.LogError("There was an error: {message}, {exception}", ex.Message, ex);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}
