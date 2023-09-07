using Microsoft.EntityFrameworkCore;

namespace BookProject.WebApp.Models
{
    public class BookDbContext : DbContext//DbContext sınıfından kalıtım aldık. dbcontext altı kızarsa eğer alt+enter a bas
    {
        //Constructor oluşturma
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set;} //veritabanındaki verileri kullanmak için.

    }
}
