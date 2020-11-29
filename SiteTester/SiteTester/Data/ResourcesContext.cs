using Microsoft.EntityFrameworkCore;

namespace SiteTester.Data
{
    public class ResourcesContext: DbContext
    {
        public ResourcesContext(DbContextOptions options) :base (options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Resource> Resources { get; set; }
      
    }
}
