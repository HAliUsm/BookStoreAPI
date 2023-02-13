using Microsoft.AspNetCore.Mvc;
using BookStoreAPI.EfCore;
using BookStoreAPI.Services;

namespace BookStoreAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : Controller
{
    private readonly BookService _bookService;

    public BooksController(BookService bookService) =>
        _bookService = bookService;

    [HttpGet]
    public async Task<List<Book>> Get() =>
        await _bookService.GetAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Book>> Get(int id)
    {
        Console.WriteLine("BookController Accessed");
        var book = await _bookService.GetAsync(id);
        
        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Book newBook)
    {
        await _bookService.CreateAsync(newBook);
        return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Book updatedBook)
    {
        var book = await _bookService.GetAsync(id);
        if (book is null)
        {
            return NotFound();
        }

        updatedBook.Id = book.Id;

        await _bookService.UpdateAsync(id, updatedBook);

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _bookService.GetAsync(id);
        if (book is null)
        {
            return NotFound();
        }

        await _bookService.RemoveAsync(id);

        return NoContent();
    }

}