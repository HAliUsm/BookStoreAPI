// using BookStoreAPI.Models;
// using Microsoft.Extensions.Options;
// using MongoDB.Driver;
// using Book = BookStoreAPI.Models;
// using Context = BookStoreAPI.Models.BookStoreContext
// // This file is communication with the database 
//

using BookStoreAPI.EfCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Services;

public class BookService
{
    private readonly BookStoreContext _context;

     public BookService(BookStoreContext context)
     {
         _context = context;
     }

     public async Task<List<EfCore.Book>> GetAsync() =>
         await _context.Books.ToListAsync();

     public async Task<Book?> GetAsync(int id) =>
         await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

     public async Task CreateAsync(Book newBook)
     {
         await _context.Books.AddAsync(newBook);
         await _context.SaveChangesAsync();
     }


     public async Task UpdateAsync(int id, Book updatedBook)
     {
         var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
         if (book != null)
         {
             book.BookName = updatedBook.BookName;
             book.Author = updatedBook.Author;
             book.Category = updatedBook.Category;
             book.Price = updatedBook.Price;
             _context.Books.Update(book);
             await _context.SaveChangesAsync();
         }
     }


     public async Task RemoveAsync(int id)
     {
         var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
         if (book != null)
         {
             _context.Books.Remove(book);
             await _context.SaveChangesAsync();
         }
     }


}