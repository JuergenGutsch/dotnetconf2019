using Microsoft.AspNetCore.Mvc;

namespace DncWeatherStats.Station3.Controllers
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
