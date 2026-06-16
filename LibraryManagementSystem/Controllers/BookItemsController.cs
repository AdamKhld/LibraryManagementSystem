using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Models;

[Route("api/BookItems")]
[ApiController]
public class BookItemsController : ControllerBase
{
    private readonly BookContext _context;
    public BookItemsController(BookContext context)
    {
        _context = context;
    }

    // GET: api/BookItem
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookItem>>> GetBookItem()
    {
        return await _context.BookItems.ToListAsync();
    }

    // GET: api/BookItem/5
    [HttpGet("{id}")]
    public async Task<ActionResult<BookItem>> GetBookItem(long id)
    {
        var bookitem = await _context.BookItems.FindAsync(id);

        if (bookitem == null)
        {
            return NotFound();
        }

        return bookitem;
    }

    // PUT: api/BookItem/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBookItem(long? id, BookItem bookitem)
    {
        if (id != bookitem.Id)
        {
            return BadRequest();
        }

        _context.Entry(bookitem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BookItemExists(id))
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

    // POST: api/BookItem
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<BookItem>> PostBookItem(BookItem bookitem)
    {
        _context.BookItems.Add(bookitem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBookItem), new { id = bookitem.Id }, bookitem);
    }

    // DELETE: api/BookItem/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBookItem(long? id)
    {
        var bookitem = await _context.BookItems.FindAsync(id);
        if (bookitem == null)
        {
            return NotFound();
        }

        _context.BookItems.Remove(bookitem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BookItemExists(long? id)
    {
        return _context.BookItems.Any(e => e.Id == id);
    }
}
