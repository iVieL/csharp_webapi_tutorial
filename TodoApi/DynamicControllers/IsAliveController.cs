using Microsoft.AspNetCore.Mvc;

namespace TodoApi.DynamicControllers
{
    [Route("[controller]")]
    [ApiController]
    public class IsAliveController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "OK";
        }
    }
}