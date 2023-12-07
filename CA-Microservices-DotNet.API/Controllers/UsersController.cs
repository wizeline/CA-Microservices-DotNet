using CA_Microservices_DotNet.Domain.Entities;
using CA_Microservices_DotNet.Domain.Interfaces.Repositories;
using CA_Microservices_DotNet.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CA_Microservices_DotNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            var response = await _userService.GetAllUsers();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var response = await _userService.GetUser(id);
            return Ok(response);
        }
    }
}
