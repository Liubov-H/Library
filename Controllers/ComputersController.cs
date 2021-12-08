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
    public class ComputersController : ControllerBase
    {
        private readonly libraryContext _context;

        public ComputersController(libraryContext context)
        {
            _context = context;
        }

        // GET: api/Computers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Computers>>> GetComputers()
        {
            return await _context.Computers.ToListAsync();
        }

        // GET: api/Computers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Computers>> GetComputers(int id)
        {
            var computers = await _context.Computers.FindAsync(id);

            if (computers == null)
            {
                return NotFound();
            }

            return computers;
        }

        // PUT: api/Computers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComputers(int id, Computers computers)
        {
            if (id != computers.IdComputer)
            {
                return BadRequest();
            }

            _context.Entry(computers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputersExists(id))
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

        // POST: api/Computers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Computers>> PostComputers(Computers computers)
        {
            _context.Computers.Add(computers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComputers", new { id = computers.IdComputer }, computers);
        }

        // DELETE: api/Computers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Computers>> DeleteComputers(int id)
        {
            var computers = await _context.Computers.FindAsync(id);
            if (computers == null)
            {
                return NotFound();
            }

            _context.Computers.Remove(computers);
            await _context.SaveChangesAsync();

            return computers;
        }

        private bool ComputersExists(int id)
        {
            return _context.Computers.Any(e => e.IdComputer == id);
        }
    }
}
