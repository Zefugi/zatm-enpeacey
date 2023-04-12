using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Enpeacey.Backend.Security;

namespace Enpeacey.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebugController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello, World!";
        }

        [HttpGet("Auth")]
        [ApiKey]
        public ActionResult<object> Auth()
        {
            return new Response
            {
                Message = "Hello, Authorized World!"
            };
        }
    }
}

public class Response
{
    public string Message { get; set; }
}