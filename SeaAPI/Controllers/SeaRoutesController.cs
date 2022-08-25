using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeaAPI.DTO;
using SeaAPI.Models;
using SeaAPI.Services;

namespace SeaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeaRoutesController : ControllerBase
    {
        [HttpPost]
        public List<SeaRouteDTO> GetSeaRoutesForAPackage(CargoDTO cargoDTO)
        {
            SeaRouteCalculationService service = new SeaRouteCalculationService();
            return service.GetSeaRoutesForCargo(cargoDTO);
        }
    }
}
