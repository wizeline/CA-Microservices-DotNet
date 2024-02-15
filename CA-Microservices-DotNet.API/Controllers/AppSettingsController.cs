using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CA_Microservices_DotNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppSettingsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> GetAppSettings()
        {
            return Ok("true");
        }
    }
}
