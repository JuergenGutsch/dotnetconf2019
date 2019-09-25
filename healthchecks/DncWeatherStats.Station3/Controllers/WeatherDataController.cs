using System;
using System.Collections.Generic;
using System.Linq;
using DncWeatherStats.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DncWeatherStats.Station3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherDataController : ControllerBase
    {
        private readonly ILogger<WeatherDataController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public WeatherDataController(
            ILogger<WeatherDataController> logger,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<WeatherData> Get()
        {
            var data = _dbContext.WeatherData
                .Where(x => x.WeatherStationId == "USC00454169") // KENT, WA US
                .ToArray();

            return data;
        }
    }
}
