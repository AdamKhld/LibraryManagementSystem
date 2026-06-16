using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) 
        {

        }

        public DbSet<BookItem> BookItems { get; set; } = null!; 
    }
}
