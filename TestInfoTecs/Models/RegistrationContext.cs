using System.Data.Entity;

namespace TestInfoTecs.Models
{
    public class RegistrationContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<City> Cities { get; set; }
    }
}