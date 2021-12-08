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
    public class BooksGenresController : ControllerBase
    {
        private readonly libraryContext _context;

        public BooksGenresController(libraryContext context)
        {
            _context = context;
        }

        // GET: api/BooksGenres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BooksGenres>>> GetBooksGenres()
        {
            return await _context.BooksGenres.ToListAsync();
        }

        // GET: api/BooksGenres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BooksGenres>> GetBooksGenres(int id)
        {
            var booksGenres = await _context.BooksGenres.FindAsync(id);

            if (booksGenres == null)
            {
                return NotFound();
            }

            return booksGenres;
        }

        // PUT: api/BooksGenres/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooksGenres(int id, BooksGenres booksGenres)
        {
            if (id != booksGenres.IdBook)
            {
                return BadRequest();
            }

            _context.Entry(booksGenres).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksGenresExists(id))
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

        // POST: api/BooksGenres
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BooksGenres>> PostBooksGenres(BooksGenres booksGenres)
        {
            _context.BooksGenres.Add(booksGenres);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BooksGenresExists(booksGenres.IdBook))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBooksGenres", new { id = booksGenres.IdBook }, booksGenres);
        }

        // DELETE: api/BooksGenres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BooksGenres>> DeleteBooksGenres(int id)
        {
            var booksGenres = await _context.BooksGenres.FindAsync(id);
            if (booksGenres == null)
            {
                return NotFound();
            }

            _context.BooksGenres.Remove(booksGenres);
            await _context.SaveChangesAsync();

            return booksGenres;
        }

        private bool BooksGenresExists(int id)
        {
            return _context.BooksGenres.Any(e => e.IdBook == id);
        }
    }
}
