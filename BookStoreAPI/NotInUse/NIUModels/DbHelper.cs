// using BookStoreAPI.EfCore;
// using Microsoft.EntityFrameworkCore;
// using Book = BookStoreAPI.Models.Book;
// using Microsoft.Extensions.Options;
//
// namespace BookStoreAPI.Services;
//
// public class DbHelper
// {
//     private BookStoreContext _context;
//
//     public DbHelper(BookStoreContext context)
//     {
//         _context = context;
//     }
//
//     // GET all
//     public async Task<List<Book>> GetAsync()
//     {
//         List<Book> response = new List<Book>();
//        var BookList = await _context.Books.ToListAsync();
//          BookList.ForEach(row => response.Add(new Book()
//         {
//             Id = row.Id,
//             BookName = row.BookName,
//             Price = row.Price,
//             Category = row.Category,
//             Author = row.Author
//         }));
//         return response;
//     }
//     
//     public async Task<Book?> GetAsync(int Id)
//     {
//         Book response = new Book();
//         var row = await _context.Books.FirstOrDefaultAsync(d => d.Id.Equals(Id));
//         if (row != null)
//             return new Book()
//             {
//                 Id = row.Id,
//                 BookName = row.BookName,
//                 Price = row.Price,
//                 Category = row.Category,
//                 Author = row.Author
//             };
//         return null;
//     }
//     
//     public async Task SaveBookAsync(Book newBook)
//     {
//         
//     }
//      
//
//
//
// }