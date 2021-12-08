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
    public class BooksRentalsController : ControllerBase
    {
        private readonly libraryContext _context;

        public BooksRentalsController(libraryContext context)
        {
            _context = context;
        }

        // GET: api/BooksRentals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BooksRental>>> GetBooksRental()
        {
            return await _context.BooksRental.ToListAsync();
        }

        // GET: api/BooksRentals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BooksRental>> GetBooksRental(int id)
        {
            var booksRental = await _context.BooksRental.FindAsync(id);

            if (booksRental == null)
            {
                return NotFound();
            }

            return booksRental;
        }

        // PUT: api/BooksRentals/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooksRental(int id, BooksRental booksRental)
        {
            if (id != booksRental.IdBook)
            {
                return BadRequest();
            }

            _context.Entry(booksRental).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksRentalExists(id))
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

        // POST: api/BooksRentals
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BooksRental>> PostBooksRental(BooksRental booksRental)
        {
            _context.BooksRental.Add(booksRental);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BooksRentalExists(booksRental.IdBook))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBooksRental", new { id = booksRental.IdBook }, booksRental);
        }

        // DELETE: api/BooksRentals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BooksRental>> DeleteBooksRental(int id)
        {
            var booksRental = await _context.BooksRental.FindAsync(id);
            if (booksRental == null)
            {
                return NotFound();
            }

            _context.BooksRental.Remove(booksRental);
            await _context.SaveChangesAsync();

            return booksRental;
        }

        private bool BooksRentalExists(int id)
        {
            return _context.BooksRental.Any(e => e.IdBook == id);
        }
    }
}
