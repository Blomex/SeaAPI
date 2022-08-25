using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeaAPI.Models;

namespace SeaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingModelsController : ControllerBase
    {
        private readonly DataContext _context;

        public BookingModelsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BookingModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingModel>>> GetBookingModel()
        {
          if (_context.BookingModel == null)
          {
              return NotFound();
          }
            return await _context.BookingModel.ToListAsync();
        }

        // GET: api/BookingModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingModel>> GetBookingModel(int id)
        {
          if (_context.BookingModel == null)
          {
              return NotFound();
          }
            var bookingModel = await _context.BookingModel.FindAsync(id);

            if (bookingModel == null)
            {
                return NotFound();
            }

            return bookingModel;
        }

        // PUT: api/BookingModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingModel(int id, BookingModel bookingModel)
        {
            if (id != bookingModel.id)
            {
                return BadRequest();
            }

            _context.Entry(bookingModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookingModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingModel>> PostBookingModel(BookingModel bookingModel)
        {
          if (_context.BookingModel == null)
          {
              return Problem("Entity set 'DataContext.BookingModel'  is null.");
          }
            _context.BookingModel.Add(bookingModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingModel", new { id = bookingModel.id }, bookingModel);
        }

        // DELETE: api/BookingModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingModel(int id)
        {
            if (_context.BookingModel == null)
            {
                return NotFound();
            }
            var bookingModel = await _context.BookingModel.FindAsync(id);
            if (bookingModel == null)
            {
                return NotFound();
            }

            _context.BookingModel.Remove(bookingModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingModelExists(int id)
        {
            return (_context.BookingModel?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
