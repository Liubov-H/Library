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
    public class BooksController : ControllerBase
    {
        private readonly libraryContext _context;

        public BooksController(libraryContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Books>> GetBooks(int id)
        {
            var books = await _context.Books.FindAsync(id);

            if (books == null)
            {
                return NotFound();
            }

            return books;
        }

        [HttpGet("BooksGenres")]
        public ActionResult<List<BooksGenresNames>> Get()
        {
            libraryContext db = new libraryContext();
            var result = (from books in db.Books
                          join booksGenres in db.BooksGenres on books.IdBook equals booksGenres.IdBook
                          join genres in db.Genres on booksGenres.IdGenre equals genres.IdGenre
                          select new BooksGenresNames()
                          {
                              IdBook = books.IdBook,
                              NameBook = books.Name,
                              NameGenre = genres.Name,
                          }).ToList();

            return result;
        }

        [HttpGet("BooksGenres/{id}")]
        public ActionResult<List<BooksGenresNames>> Get(int id)
        {
            libraryContext db = new libraryContext();
            var result = (from books in db.Books
                          join booksGenres in db.BooksGenres on books.IdBook equals booksGenres.IdBook
                          join genres in db.Genres on booksGenres.IdGenre equals genres.IdGenre
                          where books.IdBook==id
                          select new BooksGenresNames()
                          {
                              IdBook = books.IdBook,
                              NameBook = books.Name,
                              NameGenre = genres.Name,
                          }).ToList();

            return result;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooks(int id, Books books)
        {
            if (id != books.IdBook)
            {
                return BadRequest();
            }

            _context.Entry(books).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksExists(id))
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

        // POST: api/Books
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Books>> PostBooks(Books books)
        {
            _context.Books.Add(books);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooks", new { id = books.IdBook }, books);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Books>> DeleteBooks(int id)
        {
            var books = await _context.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }

            _context.Books.Remove(books);
            await _context.SaveChangesAsync();

            return books;
        }

        private bool BooksExists(int id)
        {
            return _context.Books.Any(e => e.IdBook == id);
        }
    }
}
