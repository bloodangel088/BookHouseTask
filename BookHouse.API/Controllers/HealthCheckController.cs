using Microsoft.AspNetCore.Mvc;

namespace BookHouse.API.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Check()
        {
            return Ok("Hello, I am working!");
        }
    }
}
