using Microsoft.EntityFrameworkCore;
using PublisherDomain;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PublisherData
{
    //DbContext provides EF Core's database connectivity and tracks changes to objects.
    //DbSet wraps the classes that EF Core will work with.
    public class PubContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(
                "Data Source = DESKTOP-1C7B29R; Initial Catalog = PubDatabase; Integrated Security = True; Pooling = False; Encrypt = True; Trust Server Certificate = True");
        }
    }
}
