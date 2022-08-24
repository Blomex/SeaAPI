using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeaAPI.Models;

namespace SeaAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeaRouteModelsController : ControllerBase
    {
        private readonly DataContext _context;

        public SeaRouteModelsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SeaRouteModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeaRouteModel>>> GetSeaRoutes()
        {

            if (_context.SeaRoutes == null)
            {
                return NotFound();
            }
            return await _context.SeaRoutes.ToListAsync();
        }

        // GET: api/SeaRouteModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeaRouteModel>> GetSeaRouteModel(int id)
        {
            if (_context.SeaRoutes == null)
            {
                return NotFound();
            }
            var seaRouteModel = await _context.SeaRoutes.FindAsync(id);

            if (seaRouteModel == null)
            {
                return NotFound();
            }

            return seaRouteModel;
        }

        // POST: api/SeaRouteModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PutSeaRouteModel(SeaRouteModel seaRouteModel)
        {

            _context.Entry(seaRouteModel).State = EntityState.Modified;
            Console.WriteLine(seaRouteModel.ToString);

            return Content("ok");
        }
        /*
        // POST: api/SeaRouteModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SeaRouteModel>> PostSeaRouteModel(SeaRouteModel seaRouteModel)
        {
          if (_context.SeaRoutes == null)
          {
              return Problem("Entity set 'DataContext.SeaRoutes'  is null.");
          }
            _context.SeaRoutes.Add(seaRouteModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeaRouteModel", new { id = seaRouteModel.Id }, seaRouteModel);
        }*/

        // DELETE: api/SeaRouteModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeaRouteModel(int id)
        {
            if (_context.SeaRoutes == null)
            {
                return NotFound();
            }
            var seaRouteModel = await _context.SeaRoutes.FindAsync(id);
            if (seaRouteModel == null)
            {
                return NotFound();
            }

            _context.SeaRoutes.Remove(seaRouteModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeaRouteModelExists(int id)
        {
            return (_context.SeaRoutes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
