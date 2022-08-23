using Microsoft.AspNetCore.Mvc;
using SeaAPI.Models;

namespace SeaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeaRouteController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<SeaRouteController> _logger;

        public SeaRouteController(ILogger<SeaRouteController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetRoute")]
        public IEnumerable<SeaRouteModel> Post()
        {
            return Enumerable.Range(1, 5).Select(index => new SeaRouteModel
            {
               /* Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]*/
            })
            .ToArray();
        }
    }
}