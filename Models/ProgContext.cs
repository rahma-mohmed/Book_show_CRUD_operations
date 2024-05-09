using Microsoft.EntityFrameworkCore;


namespace TaskIT.Models
{
    public class ProgContext : DbContext
    {


        public ProgContext() : base()
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BookDb2 ;Integrated Security=True");
        }
    }
}
