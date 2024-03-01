using CA_Microservices_DotNet.Common.Models;
using CA_Microservices_DotNet.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CA_Microservices_DotNet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly ILogger<BooksController> _logger;

    public BooksController(IBookService bookService, ILogger<BooksController> logger)
    {
        _bookService = bookService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookModel>>> Get(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Request to BookController");
        var response = await _bookService.GetAllBooks(cancellationToken);

        _logger.LogInformation("Found books: {books}", response); 
        
        return Ok(response);
    }
}
