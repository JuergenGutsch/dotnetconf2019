using Microsoft.AspNetCore.Mvc;

namespace DncWeatherStats.Station1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "OK";
        }
    }
}
