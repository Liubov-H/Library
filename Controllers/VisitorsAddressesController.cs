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
    public class VisitorsAddressesController : ControllerBase
    {
        private readonly libraryContext _context;

        public VisitorsAddressesController(libraryContext context)
        {
            _context = context;
        }

        // GET: api/VisitorsAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitorsAddress>>> GetVisitorsAddress()
        {
            return await _context.VisitorsAddress.ToListAsync();
        }

        // GET: api/VisitorsAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VisitorsAddress>> GetVisitorsAddress(int id)
        {
            var visitorsAddress = await _context.VisitorsAddress.FindAsync(id);

            if (visitorsAddress == null)
            {
                return NotFound();
            }

            return visitorsAddress;
        }

        // PUT: api/VisitorsAddresses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitorsAddress(int id, VisitorsAddress visitorsAddress)
        {
            if (id != visitorsAddress.IdAddress)
            {
                return BadRequest();
            }

            _context.Entry(visitorsAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitorsAddressExists(id))
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

        // POST: api/VisitorsAddresses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VisitorsAddress>> PostVisitorsAddress(VisitorsAddress visitorsAddress)
        {
            _context.VisitorsAddress.Add(visitorsAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVisitorsAddress", new { id = visitorsAddress.IdAddress }, visitorsAddress);
        }

        // DELETE: api/VisitorsAddresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VisitorsAddress>> DeleteVisitorsAddress(int id)
        {
            var visitorsAddress = await _context.VisitorsAddress.FindAsync(id);
            if (visitorsAddress == null)
            {
                return NotFound();
            }

            _context.VisitorsAddress.Remove(visitorsAddress);
            await _context.SaveChangesAsync();

            return visitorsAddress;
        }

        private bool VisitorsAddressExists(int id)
        {
            return _context.VisitorsAddress.Any(e => e.IdAddress == id);
        }
    }
}
