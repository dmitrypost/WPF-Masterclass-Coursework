using Contacts.Models;
using System.Data.Entity;

namespace Contacts.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("AppContext")
        {
            
        }

        public virtual DbSet<Contact> Contacts { get; set; }

    }
}
