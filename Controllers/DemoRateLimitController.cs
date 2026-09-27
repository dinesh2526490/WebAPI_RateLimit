using Microsoft.AspNetCore.Mvc;

namespace WebAPI_RateLimit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoRateLimitController : ControllerBase
    {
        [HttpGet]      
        public IActionResult GetProducts()
        {
            return Ok(new
            {
                Message = "Success"
            });
        }
    }
}
