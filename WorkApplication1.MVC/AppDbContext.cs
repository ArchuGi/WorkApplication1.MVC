using Microsoft.EntityFrameworkCore;
using Models;

namespace WorkApplication1.MVC
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<ContactEmployee> ContactEmployee { get; set; }
    }
}
