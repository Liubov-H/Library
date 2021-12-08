using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputersRentalsController : ControllerBase
    {
        private readonly libraryContext _context;

        public ComputersRentalsController(libraryContext context)
        {
            _context = context;
        }

        // GET: api/ComputersRentals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComputersRental>>> GetComputersRental()
        {
            return await _context.ComputersRental.ToListAsync();
        }

        // GET: api/ComputersRentals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComputersRental>> GetComputersRental(int id)
        {
            var computersRental = await _context.ComputersRental.FindAsync(id);

            if (computersRental == null)
            {
                return NotFound();
            }

            return computersRental;
        }

        // PUT: api/ComputersRentals/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComputersRental(int id, ComputersRental computersRental)
        {
            if (id != computersRental.IdComputer)
            {
                return BadRequest();
            }

            _context.Entry(computersRental).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputersRentalExists(id))
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

        // POST: api/ComputersRentals
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ComputersRental>> PostComputersRental(ComputersRental computersRental)
        {
            _context.ComputersRental.Add(computersRental);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ComputersRentalExists(computersRental.IdComputer))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetComputersRental", new { id = computersRental.IdComputer }, computersRental);
        }

        // DELETE: api/ComputersRentals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ComputersRental>> DeleteComputersRental(int id)
        {
            var computersRental = await _context.ComputersRental.FindAsync(id);
            if (computersRental == null)
            {
                return NotFound();
            }

            _context.ComputersRental.Remove(computersRental);
            await _context.SaveChangesAsync();

            return computersRental;
        }

        private bool ComputersRentalExists(int id)
        {
            return _context.ComputersRental.Any(e => e.IdComputer == id);
        }
    }
}
