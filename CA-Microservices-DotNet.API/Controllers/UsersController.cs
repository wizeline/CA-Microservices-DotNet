using CA_Microservices_DotNet.Domain.Entities;
using CA_Microservices_DotNet.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CA_Microservices_DotNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            _logger.LogInformation("Attending GET: users");

            var response = await _userService.GetAllUsers();

            _logger.LogInformation("GET: user response: {response}", response);

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            var response = await _userService.GetUser(id);
            return Ok(response);
        }
    }
}
