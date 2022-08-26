using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeaAPI.Domain;
using SeaAPI.DTO;
using SeaAPI.Models;
using SeaAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpPost]
        public IActionResult GetRoutes(CargoWithRouteDTO cargoDTO)
        {
            Cargo cargo;
            try
            {
                cargo = new Cargo(cargoDTO);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(new { message = "Such category does not exist." });
            }
            SeaRouteCalculationService service = new SeaRouteCalculationService();

            if (cargo.Category == CargoCategory.RECORDED_DELIVERY || cargo.Category == CargoCategory.CAUTIOUS_PARCELS)
            {
                return BadRequest(new { message = "Recorded deliveries and cautious parcels are not allowed." });
            }

            if (!(cargo.Weight > 0 && cargo.Weight < 100001))
            {
                return BadRequest(new { message = "Cargo weight has to be > 0 and < 100001 (grams)." });
            }

            if (!(cargo.DimensionX > 0 && cargo.DimensionX < 401 && cargo.DimensionY > 0 && cargo.DimensionY < 401 && cargo.DimensionZ > 0 && cargo.DimensionZ < 401))
            {
                return BadRequest(new { message = "Cargo dimensions have to be > 0 (cm)." });
            }

            RouteCalculator calculator = new RouteCalculator();
            calculator.prepareToCalculate(cargoDTO);
            calculator.getRoutesForAllGraphs(cargoDTO.Source, cargoDTO.Destination);
            CalculatorDTO[] calculations = new CalculatorDTO[2];
            calculations[0] = new CalculatorDTO(cargoDTO.CompanyId, calculator.cheapestTime, calculator.cheapestCost, cargoDTO.StartDate, calculator.cheapestRoute, cargoDTO.Category);
            calculations[1] = new CalculatorDTO(cargoDTO.CompanyId, calculator.fastestTime, calculator.fastestCost, cargoDTO.StartDate, calculator.fastestRoute, cargoDTO.Category);

            return Ok(JsonConvert.SerializeObject(calculations, Formatting.Indented));
        }
    }
}
