using System.Data.Entity;
using Weather.Models;

namespace Weather.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("AppContext")
        {
            
        }

        public virtual DbSet<Setting> Settings { get; set; }

    }
}
