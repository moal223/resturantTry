using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace resturant.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> test(){
            return Ok("Ok");
        }
    }
}