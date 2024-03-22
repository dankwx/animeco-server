using Microsoft.AspNetCore.Mvc;
using System;

namespace WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingsController : ControllerBase
    {
        [HttpGet(Name = "GetGreetings")]
        public IActionResult Get()
        {
            var currentTime = DateTime.Now;
            var greetingMessage = $"Hello! Current date and time is {currentTime}.";
            return Ok(greetingMessage);
        }
    }
}
