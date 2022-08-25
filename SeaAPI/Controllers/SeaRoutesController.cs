using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore;
using SeaAPI.Domain;
using SeaAPI.DTO;
using SeaAPI.Models;
using SeaAPI.Services;
using System.Net.Mail;

namespace SeaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeaRoutesController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetSeaRoutesForAPackage(CargoDTO cargoDTO)
        {
            Cargo cargo;
            try
            {
                cargo = new Cargo(cargoDTO);
            } catch (InvalidDataException e)
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

            if (cargo.DimensionX <= 0 || cargo.DimensionY <=0 || cargo.DimensionZ <= 0) 
            {
                return BadRequest(new { message = "Cargo dimensions have to be > 0 (cm)." });
            }

            List<SeaRouteDTO> results = service.GetSeaRoutesForCargo(cargo);

            return Ok(results);
        }
    }
}
