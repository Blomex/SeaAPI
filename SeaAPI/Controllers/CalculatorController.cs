using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeaAPI.Domain;
using SeaAPI.DTO;
using SeaAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpPost]
        public string GetRoutes(CargoWithRouteDTO cargoDTO)
        {
            RouteCalculator calculator = new RouteCalculator();
            calculator.prepareToCalculate(cargoDTO);
            calculator.getRoutesForAllGraphs(cargoDTO.Source, cargoDTO.Destination);
            CalculatorDTO[] calculations = new CalculatorDTO[2];
            calculations[0] = new CalculatorDTO(cargoDTO.CompanyId, calculator.cheapestTime, calculator.cheapestCost, cargoDTO.StartDate, calculator.cheapestRoute, cargoDTO.Category);
            calculations[1] = new CalculatorDTO(cargoDTO.CompanyId, calculator.fastestTime, calculator.fastestCost, cargoDTO.StartDate, calculator.fastestRoute, cargoDTO.Category);

            return JsonConvert.SerializeObject(calculations, Formatting.Indented);

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // GET api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "hello", "world"};
        }

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
