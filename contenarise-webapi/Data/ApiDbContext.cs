using Microsoft.EntityFrameworkCore;

namespace contenarise_webapi
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base (options) {}

        public DbSet<Driver> Drivers {set;get;}


    }
}