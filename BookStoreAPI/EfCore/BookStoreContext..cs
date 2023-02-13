using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.EfCore
{

    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext>
            options)
            : base(options)
        {
         }

        public DbSet<Book> Books { get; set; }
    }

}