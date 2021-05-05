using Microsoft.EntityFrameworkCore;

namespace MyFirstApi
{
    public class AppContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }

        public AppContext(DbContextOptions options)
            :base(options)
        {

        }
    }
}