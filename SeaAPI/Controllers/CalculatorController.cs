using Microsoft.AspNetCore.Mvc;
using SeaAPI.Domain;
using SeaAPI.DTO;
using SeaAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeaAPI.Controllers
{
    [Route("api/calculate")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpPost]
        public IEnumerable<CalculatorDTO> GetRoutes(CargoWithRouteDTO cargoDTO)
        {
            RouteCalculator calculator = new RouteCalculator();
            calculator.getRoutesForAllGraphs(cargoDTO.Source, cargoDTO.Destination);
            CalculatorDTO[] calculations = new CalculatorDTO[2];
            calculations[0] = new CalculatorDTO(calculator.fastestTime, calculator.fastestCost, cargoDTO.StartDate, calculator.fastestRoute, Enum.GetName(typeof(CargoCategory), cargoDTO.Category));
            calculations[1] = new CalculatorDTO(calculator.cheapestTime, calculator.cheapestCost, cargoDTO.StartDate, calculator.fastestRoute, Enum.GetName(typeof(CargoCategory), cargoDTO.Category));
            return calculations;

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        /*
        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }*/

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
