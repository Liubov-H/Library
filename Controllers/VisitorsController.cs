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
    public class VisitorsController : ControllerBase
    {
        private readonly libraryContext _context;

        public VisitorsController(libraryContext context)
        {
            _context = context;
        }

        // GET: api/Visitors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visitors>>> GetVisitors()
        {
            return await _context.Visitors.ToListAsync();
        }

        // GET: api/Visitors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Visitors>> GetVisitors(int id)
        {
            var visitors = await _context.Visitors.FindAsync(id);

            if (visitors == null)
            {
                return NotFound();
            }

            return visitors;
        }

        // PUT: api/Visitors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisitors(int id, Visitors visitors)
        {
            if (id != visitors.IdVisitor)
            {
                return BadRequest();
            }

            _context.Entry(visitors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitorsExists(id))
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

        // POST: api/Visitors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Visitors>> PostVisitors(Visitors visitors)
        {
            _context.Visitors.Add(visitors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVisitors", new { id = visitors.IdVisitor }, visitors);
        }

        // DELETE: api/Visitors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Visitors>> DeleteVisitors(int id)
        {
            var visitors = await _context.Visitors.FindAsync(id);
            if (visitors == null)
            {
                return NotFound();
            }

            _context.Visitors.Remove(visitors);
            await _context.SaveChangesAsync();

            return visitors;
        }

        private bool VisitorsExists(int id)
        {
            return _context.Visitors.Any(e => e.IdVisitor == id);
        }
    }
}
