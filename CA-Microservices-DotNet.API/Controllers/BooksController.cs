using CA_Microservices_DotNet.Domain.Entities;
using CA_Microservices_DotNet.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CA_Microservices_DotNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get()
        {
            var response = await _bookService.GetAllBooks();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var response = await _bookService.GetBook(id);
            return Ok(response);
        }
    }
}
